using Common;
using System.Collections.Generic;

namespace RCClient {
    class Settings : SerializableStruct<Settings> {
        public static int port = 2386;
        public static int fastTimeout = 65;
        public static int normalTimeout = 2500;
        public static List<DeviceItem> devices = new List<DeviceItem>();
    }
    class Settings2 : SerializableStruct<Settings2> {
        public int port = 2386;
        public int fastTimeout = 65;
        public int normalTimeout = 2500;
        public List<DeviceItem> devices = new List<DeviceItem>();
    }
}
