using System;
using System.Collections.Generic;
using System.IO;

namespace Common {
    public enum PacketType {
        Info,
        Auth,
        RequestVNC
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

    public abstract class SerializableStruct<T> where T: SerializableStruct<T> {
        private static List<Action<T, BinaryWriter>> serializerSteps;
        private static List<Action<T, BinaryReader>> deserializerSteps;

        static SerializableStruct () {
            serializerSteps = new List<Action<T, BinaryWriter>>();
            deserializerSteps = new List<Action<T, BinaryReader>>();
            var fields = typeof(T).GetFields();
            foreach (var field in fields) {
                if (field.FieldType == typeof(string)) {
                    serializerSteps.Add((obj, writer) => writer.Write((string) field.GetValue(obj)));
                    deserializerSteps.Add((obj, reader) => field.SetValue(obj, reader.ReadString()));
                } else if (field.FieldType == typeof(float)) {
                    serializerSteps.Add((obj, writer) => writer.Write((float) field.GetValue(obj)));
                    deserializerSteps.Add((obj, reader) => field.SetValue(obj, reader.ReadSingle()));
                } else if (field.FieldType == typeof(ulong)) {
                    serializerSteps.Add((obj, writer) => writer.Write((ulong) field.GetValue(obj)));
                    deserializerSteps.Add((obj, reader) => field.SetValue(obj, reader.ReadUInt64()));
                } else if (field.FieldType == typeof(long)) {
                    serializerSteps.Add((obj, writer) => writer.Write((long) field.GetValue(obj)));
                    deserializerSteps.Add((obj, reader) => field.SetValue(obj, reader.ReadInt64()));
                } else if (field.FieldType == typeof(uint)) {
                    serializerSteps.Add((obj, writer) => writer.Write((uint) field.GetValue(obj)));
                    deserializerSteps.Add((obj, reader) => field.SetValue(obj, reader.ReadUInt32()));
                } else if (field.FieldType == typeof(int)) {
                    serializerSteps.Add((obj, writer) => writer.Write((int) field.GetValue(obj)));
                    deserializerSteps.Add((obj, reader) => field.SetValue(obj, reader.ReadInt32()));
                } else if (field.FieldType == typeof(ushort)) {
                    serializerSteps.Add((obj, writer) => writer.Write((ushort) field.GetValue(obj)));
                    deserializerSteps.Add((obj, reader) => field.SetValue(obj, reader.ReadUInt16()));
                } else if (field.FieldType == typeof(short)) {
                    serializerSteps.Add((obj, writer) => writer.Write((short) field.GetValue(obj)));
                    deserializerSteps.Add((obj, reader) => field.SetValue(obj, reader.ReadInt16()));
                } else if (field.FieldType == typeof(double)) {
                    serializerSteps.Add((obj, writer) => writer.Write((double) field.GetValue(obj)));
                    deserializerSteps.Add((obj, reader) => field.SetValue(obj, reader.ReadDouble()));
                } else if (field.FieldType == typeof(char)) {
                    serializerSteps.Add((obj, writer) => writer.Write((char) field.GetValue(obj)));
                    deserializerSteps.Add((obj, reader) => field.SetValue(obj, reader.ReadChar()));
                } else if (field.FieldType == typeof(sbyte)) {
                    serializerSteps.Add((obj, writer) => writer.Write((sbyte) field.GetValue(obj)));
                    deserializerSteps.Add((obj, reader) => field.SetValue(obj, reader.ReadSByte()));
                } else if (field.FieldType == typeof(bool)) {
                    serializerSteps.Add((obj, writer) => writer.Write((bool) field.GetValue(obj)));
                    deserializerSteps.Add((obj, reader) => field.SetValue(obj, reader.ReadBoolean()));
                } else if (field.FieldType == typeof(decimal)) {
                    serializerSteps.Add((obj, writer) => writer.Write((decimal) field.GetValue(obj)));
                    deserializerSteps.Add((obj, reader) => field.SetValue(obj, reader.ReadDecimal()));
                } else if (field.FieldType.BaseType == typeof(Enum)) {
                    serializerSteps.Add((obj, writer) => writer.Write((int) field.GetValue(obj)));
                    deserializerSteps.Add((obj, reader) => field.SetValue(obj, reader.ReadInt32()));
                } else {
                    throw new Exception("Type of " + field.Name + " not supported");
                }
            }
        }

        public void Serialize (Stream stream) {
            var writer = new BinaryWriter(stream);
            foreach (var step in serializerSteps) step((T) this, writer);
        }

        public static T Deserialize (Stream stream) {
            var reader = new BinaryReader(stream);
            var deserializable = Activator.CreateInstance<T>();
            foreach (var step in deserializerSteps) step(deserializable, reader);
            return deserializable;
        }
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
}
