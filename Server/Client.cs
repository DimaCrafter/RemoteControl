using Common;
using RCServer.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace RCServer {
    public class Client {
        public bool isAuthed = false;
        public void ExecuteScript () {
            var script = ExecScript.Deserialize(stream);

            foreach (var step in script.steps) {
                // TODO: Сделать по-человечески
                ExecState state = null;

                // TODO: Logging
                switch (step["type"]) {
                    case "0": // RunProgram
                        state = new ExecState {
                            description = "Выполнение " + step["cmd"],
                            status = 0xFA
                        };
                        SendStruct(PacketType.ExecuteScript, state);

                        var args = "";
                        var argsCount = int.Parse(step["args"]);
                        for (var i = 0; i < argsCount; i++) {
                            args += $"\"{step["arg" + i]}\" ";
                        }

                        try {
                            Process.Start(new ProcessStartInfo {
                                FileName = step["cmd"],
                                Arguments = args,
                                WindowStyle = (ProcessWindowStyle) Enum.Parse(typeof(ProcessWindowStyle), step["windowState"]),
                            });

                            state.status = 0xFF;
                        } catch (Exception err) {
                            state.status = 0xFE;
                            state.description += " (" + err.Message + ")";
                        }
                        break;
                    case "1": // CloseProgram
                        state = new ExecState {
                            description = "Выполнение " + step["cmd"],
                            status = 0xFA
                        };
                        SendStruct(PacketType.ExecuteScript, state);

                        var procList = Process.GetProcessesByName(step["process"]);
                        var count = procList.Length;

                        if (count == 0) {
                            state.description = $"Процессы с названием {step["process"]} не найдены";
                            state.status = 0xFE;
                            break;
                        }

                        for (var i = 0; i < count; i++) {
                            var process = procList[i];
                            Win32.SendMessage(process.MainWindowHandle, Win32.WM_CLOSE, 0, IntPtr.Zero);

                            state.description = $"Завершение процесса {step["process"]} #{process.Id}";
                            state.status = (byte) (i / count * 100);

                            if (step["timeout"] != "0") {
                                if (!process.WaitForExit(int.Parse(step["timeout"]))) {
                                    process.Kill();
                                }
                            }
                        }

                        state.status = 0xFF;
                        break;
                    case "2": // SyncTime
                        writer.Write((byte) PacketType.GetTime);
                        // TODO: OnPacket
                        var time = reader.ReadInt64();
                        Win32.SetSystemTime(new DateTime(time));
                        break;
                    case "3": // SystemAction
                        switch (step["action"]) {
                            case "0":
                                Process.Start("shutdown", "/s /t 0");
                                break;
                            case "1":
                                Process.Start("shutdown", "/r /t 0");
                                break;
                            case "2":
                                Process.Start("shutdown", "/f /h /t 0");
                                break;
                        }
                        break;
                }

                // TODO: type not matched
                if (state.status == 0xFF) state.description = "";
                SendStruct(PacketType.ExecuteScript, state);
            }
        }

        private static readonly string ANYDESK_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\AnyDesk\AnyDesk.exe";
        private static Dictionary<string, string> ANYDESK_SETTINGS = new Dictionary<string, string> {
            { "ad.anynet.direct", "true" },
            { "ad.anynet.listen_port", "3170" },
            { "ad.anynet.proxy.mode", "0" },
            { "ad.security.update_type", "2" },
            { "ad.discovery.default_behavior", "0" },
            { "ad.discovery.enabled", "false" },
            { "ad.discovery.hidden", "true" }
        };

        public void RequestControl () {
            // isInstall
            if (reader.ReadBoolean()) {
                var installPath = Path.GetDirectoryName(ANYDESK_PATH);
                var installerPath = installPath + "\\installer.exe";

                File.Move(ANYDESK_PATH, installerPath);
                var installerProcess = Process.Start(installerPath, $"--silent --install \\\"{installPath}\\\"");
                installerProcess.WaitForExit();
                Process.Start(installerPath, $"--stop-service");
                File.Delete(installerPath);

                var cfgPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\AnyDesk\\system.conf";
                var newSettings = "";
                foreach (var line in File.ReadLines(cfgPath)) {
                    if (line.Length == 0) continue;

                    var pair = line.Split('=');
                    if (ANYDESK_SETTINGS.ContainsKey(pair[0])) {
                        newSettings += pair[0] + "=" + ANYDESK_SETTINGS[pair[0]] + "\n";
                    } else {
                        newSettings += line + "\n";
                    }
                }

                File.WriteAllText(cfgPath, newSettings);
            }

            var bytes = reader.ReadBytes(32);
            var passwd = "";
            foreach (var b in bytes) {
                passwd += b.ToString("x2");
            }

            var anydesk = Process.Start(new ProcessStartInfo {
                FileName = ANYDESK_PATH,
                Arguments = "--set-password --start-service",
                RedirectStandardInput = true,
                UseShellExecute = false
            });

            anydesk.StandardInput.WriteLine(passwd);
            anydesk.WaitForExit();

            Win32.ShowWindow(anydesk.MainWindowHandle, (int) Win32.SW.HIDE); // hide the window
            Win32.SetWindowLong(anydesk.MainWindowHandle, (int) Win32.GWL.STYLE, (uint) ~Win32.WS.VISIBLE); // set the style
            Win32.ShowWindow(anydesk.MainWindowHandle, (int) Win32.SW.SHOW); // show the window for the new style to come into effect
            Win32.ShowWindow(anydesk.MainWindowHandle, (int) Win32.SW.HIDE); // hide the window so we can't see it

            writer.Write((byte) 0);
        }

        private static readonly Regex PATH_ENV_REGEX = new Regex("(?:%(.*?)%)|(?:%([0-9]+))");
        public string ParsePath (string path) {
            return PATH_ENV_REGEX.Replace(path, match => {
                if (match.Groups[1].Success) {
                    return Environment.GetEnvironmentVariable(match.Groups[1].Value);
                } else if (match.Groups[2].Success) {
                    return Environment.GetFolderPath((Environment.SpecialFolder) int.Parse(match.Groups[2].Value));
                }

                return match.Value;
            });
        }

        public void ReadFile () {
            var path = ParsePath(reader.ReadString());

            if (File.Exists(path)) {
                writer.Write('1');
                return;
            }

            writer.Write('0');
            using var file = File.Create(path);
            var size = reader.ReadInt64();
            for (long i = 0; i < size; i++) {
                file.WriteByte((byte) stream.ReadByte());
            }
        }

        public unsafe void SendScreenshot () {
            var width = reader.ReadInt32();
            var height = reader.ReadInt32();

            using var bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format24bppRgb);
            using var graphics = Graphics.FromImage(bitmap);

            graphics.CopyFromScreen(
                Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y,
                0, 0,
                Screen.PrimaryScreen.Bounds.Size,
                CopyPixelOperation.SourceCopy
            );

            writer.Write((byte) PacketType.GetScreenshot);

            width = (int) ((float) Screen.PrimaryScreen.Bounds.Width / Screen.PrimaryScreen.Bounds.Height * height);
            writer.Write(width);
            writer.Write(height);

            var kx = (float) Screen.PrimaryScreen.Bounds.Width / width;
            var ky = (float) Screen.PrimaryScreen.Bounds.Height / height;
            using var resultBmp = new Bitmap(bitmap, width, height);
            var bmpData = resultBmp.LockBits(new Rectangle(Point.Empty, resultBmp.Size), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            var result = new ushort[width * height * 3];
            var length = width * height * 3;
            var dest = (byte*) bmpData.Scan0;
            for (var offset = 0; offset < length; offset++) {
                stream.WriteByte(dest[offset]);
            }

            resultBmp.UnlockBits(bmpData);
        }

        // Network methods
        private readonly TcpClient socket;
        private readonly BinaryReader reader;
        private readonly BinaryWriter writer;
        public Client (TcpClient socket) {
            this.socket = socket;
            stream = socket.GetStream();
            reader = new BinaryReader(stream);
            writer = new BinaryWriter(stream);
        }

        private NetworkStream stream;
        public byte[] Read () {
            while (true) {
                if (!socket.Connected)
                    return null;
                else if (stream.DataAvailable)
                    break;
                else
                    Thread.Sleep(100);
            }

            var packet = new byte[socket.Available];
            stream.Read(packet, 0, packet.Length);
            return packet;
        }

        public void Send (byte[] packet) {
            stream.Write(packet, 0, packet.Length);
        }

        public void SendStruct<T> (PacketType type, T structure) where T : SerializableStruct<T> {
            stream.WriteByte((byte) type);
            structure.Serialize(stream);
        }

        public void Disconnect () {
            socket.Close();
        }
    }
}
