using Common;
using RCServer.Utils;
using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading;

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
                            step = "Выполнение " + step["cmd"],
                            percent = 0xFA
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

                            state.percent = 0xFF;
                        } catch (Exception err) {
                            state.percent = 0xFE;
                            state.step += " (" + err.Message + ")";
                        }
                        break;
                    case "1": // CloseProgram
                        state = new ExecState {
                            step = "Выполнение " + step["cmd"],
                            percent = 0xFA
                        };
                        SendStruct(PacketType.ExecuteScript, state);

                        var procList = Process.GetProcessesByName(step["process"]);
                        var count = procList.Length;

                        if (count == 0) {
                            state.step = $"Процессы с названием {step["process"]} не найдены";
                            state.percent = 0xFE;
                            break;
                        }

                        for (var i = 0; i < count; i++) {
                            var process = procList[i];
                            Win32.SendMessage(process.MainWindowHandle, Win32.WM_CLOSE, 0, IntPtr.Zero);

                            state.step = $"Завершение процесса {step["process"]} #{process.Id}";
                            state.percent = (byte) (i / count * 100);

                            if (step["timeout"] != "0") {
                                if (!process.WaitForExit(int.Parse(step["timeout"]))) {
                                    process.Kill();
                                }
                            }
                        }

                        state.percent = 0xFF;
                        break;
                }

                // TODO: type not matched
                if (state.percent == 0xFF) state.step = "";
                SendStruct(PacketType.ExecuteScript, state);
            }
        }

        // Network methods
        private readonly TcpClient socket;
        public Client (TcpClient socket) {
            this.socket = socket;
            stream = socket.GetStream();
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
