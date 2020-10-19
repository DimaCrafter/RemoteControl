using System.Collections.Generic;

namespace Common {
    public enum PacketType : byte {
        Info,
        Auth,
        ExecuteScript,
        GetScreenshot,
        GetTime,
        CopyFile,
        Sync,
        RequestControl
    }

    public class DeviceInfo : SerializableStruct<DeviceInfo> {
        public string name;
        public string os;
        public int ram;
        public string cpuName;
        public int cpuCores;
        public string videocard;
        public int screenWidth;
        public int screenHeight;
        public int bpp;
    }

    public class Shortcut : SerializableStruct<Shortcut> {
        public string name;
        public string path;
        public string target;
        public string icon;

        public int xGridOffset = 0;
        public int yGridOffset = 0;
        public ShortcutAlignment aligment = 0;
    }

    public enum ShortcutAlignment {
        TopLeft, TopRight, BottomRight, BottomLeft
    }

    public class ExecScript : SerializableStruct<ExecScript> {
        public string name;
        public List<Dictionary<string, string>> steps = new List<Dictionary<string, string>>();
    }

    public class ExecState : SerializableStruct<ExecState> {
        // 0-100      Процент выполнения
        // 250 (0xFA) Задача запущена
        // 254 (0xFE) Задача выполнена с ошибкой
        // 255 (0xFF) Все задачи выполнены
        public byte status;
        public string description;

        public enum Status : byte {
            Pending = 0xFA,
            Error = 0xFE,
            Done = 0xFF
        }
    }
}
