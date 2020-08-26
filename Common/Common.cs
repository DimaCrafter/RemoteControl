using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

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
        private delegate void SerializerStep (ref object obj, BinaryWriter writer);
        private static List<SerializerStep> serializerSteps;
        private delegate void DeserializerStep (ref object obj, BinaryReader reader);
        private static List<DeserializerStep> deserializerSteps;

        static SerializableStruct () {
            serializerSteps = new List<SerializerStep>();
            deserializerSteps = new List<DeserializerStep>();
            ParseComplicated(typeof(T));
        }

        private static void ParseComplicated (Type type, FieldInfo baseField = null) {
            if (baseField == null) {
                deserializerSteps.Add((ref object obj, BinaryReader reader) => {
                    obj = Activator.CreateInstance(type);
                });

                foreach (var field in type.GetFields()) {
                    ParseSimple(field);
                }

                return;
            } else if (type.GetInterface("IList") != null) {
                var genericType = type.GetGenericArguments()[0];

                Getter getter = (ref object obj, BinaryWriter writer, Action<object> cb) => {
                    var list = (IList) baseField.GetValue(obj);
                    writer.Write(list.Count);

                    foreach (var entry in list) cb(entry);
                };

                Setter setter = (ref object obj, BinaryReader reader, Func<object> cb) => {
                    var list = (IList) Activator.CreateInstance(type);
                    
                    var length = reader.ReadInt32();
                    for (var i = 0; i < length; i++) list.Add(cb());

                    baseField.SetValue(obj, list);
                };

                ParseSimple(genericType, getter, setter);
                return;
            }

            throw new Exception("Type of " + baseField.Name + " in " + type.Name + " not supported");
        }

        private delegate void Getter (ref object obj, BinaryWriter writer, Action<object> cb);
        private delegate void Setter (ref object obj, BinaryReader reader, Func<object> cb);
        private static bool ParseSimple (Type type, Getter getter, Setter setter) {
            if (type == typeof(string)) {
                serializerSteps.Add((ref object obj, BinaryWriter writer) => {
                    getter(ref obj, writer, value => writer.Write((string) value));
                });
                deserializerSteps.Add((ref object obj, BinaryReader reader) => {
                    setter(ref obj, reader, () => reader.ReadString());
                });
            } else if (type == typeof(float)) {
                serializerSteps.Add((ref object obj, BinaryWriter writer) => {
                    getter(ref obj, writer, value => writer.Write((float) value));
                });
                deserializerSteps.Add((ref object obj, BinaryReader reader) => {
                    setter(ref obj, reader, () => reader.ReadSingle());
                });
            } else if (type == typeof(ulong)) {
                serializerSteps.Add((ref object obj, BinaryWriter writer) => {
                    getter(ref obj, writer, value => writer.Write((ulong) value));
                });
                deserializerSteps.Add((ref object obj, BinaryReader reader) => {
                    setter(ref obj, reader, () => reader.ReadUInt64());
                });
            } else if (type == typeof(long)) {
                serializerSteps.Add((ref object obj, BinaryWriter writer) => {
                    getter(ref obj, writer, value => writer.Write((long) value));
                });
                deserializerSteps.Add((ref object obj, BinaryReader reader) => {
                    setter(ref obj, reader, () => reader.ReadInt64());
                });
            } else if (type == typeof(uint)) {
                serializerSteps.Add((ref object obj, BinaryWriter writer) => {
                    getter(ref obj, writer, value => writer.Write((uint) value));
                });
                deserializerSteps.Add((ref object obj, BinaryReader reader) => {
                    setter(ref obj, reader, () => reader.ReadUInt32());
                });
            } else if (type == typeof(int)) {
                serializerSteps.Add((ref object obj, BinaryWriter writer) => {
                    getter(ref obj, writer, value => writer.Write((int) value));
                });
                deserializerSteps.Add((ref object obj, BinaryReader reader) => {
                    setter(ref obj, reader, () => reader.ReadInt32());
                });
            } else if (type == typeof(ushort)) {
                serializerSteps.Add((ref object obj, BinaryWriter writer) => {
                    getter(ref obj, writer, value => writer.Write((ushort) value));
                });
                deserializerSteps.Add((ref object obj, BinaryReader reader) => {
                    setter(ref obj, reader, () => reader.ReadUInt16());
                });
            } else if (type == typeof(short)) {
                serializerSteps.Add((ref object obj, BinaryWriter writer) => {
                    getter(ref obj, writer, value => writer.Write((short) value));
                });
                deserializerSteps.Add((ref object obj, BinaryReader reader) => {
                    setter(ref obj, reader, () => reader.ReadInt16());
                });
            } else if (type == typeof(double)) {
                serializerSteps.Add((ref object obj, BinaryWriter writer) => {
                    getter(ref obj, writer, value => writer.Write((double) value));
                });
                deserializerSteps.Add((ref object obj, BinaryReader reader) => {
                    setter(ref obj, reader, () => reader.ReadDouble());
                });
            } else if (type == typeof(char)) {
                serializerSteps.Add((ref object obj, BinaryWriter writer) => {
                    getter(ref obj, writer, value => writer.Write((char) value));
                });
                deserializerSteps.Add((ref object obj, BinaryReader reader) => {
                    setter(ref obj, reader, () => reader.ReadChar());
                });
            } else if (type == typeof(sbyte)) {
                serializerSteps.Add((ref object obj, BinaryWriter writer) => {
                    getter(ref obj, writer, value => writer.Write((sbyte) value));
                });
                deserializerSteps.Add((ref object obj, BinaryReader reader) => {
                    setter(ref obj, reader, () => reader.ReadSByte());
                });
            } else if (type == typeof(bool)) {
                serializerSteps.Add((ref object obj, BinaryWriter writer) => {
                    getter(ref obj, writer, value => writer.Write((bool) value));
                });
                deserializerSteps.Add((ref object obj, BinaryReader reader) => {
                    setter(ref obj, reader, () => reader.ReadBoolean());
                });
            } else if (type == typeof(decimal)) {
                serializerSteps.Add((ref object obj, BinaryWriter writer) => {
                    getter(ref obj, writer, value => writer.Write((decimal) value));
                });
                deserializerSteps.Add((ref object obj, BinaryReader reader) => {
                    setter(ref obj, reader, () => reader.ReadDecimal());
                });
            } else if (type.BaseType == typeof(Enum)) {
                serializerSteps.Add((ref object obj, BinaryWriter writer) => {
                    getter(ref obj, writer, value => writer.Write((int) value));
                });
                deserializerSteps.Add((ref object obj, BinaryReader reader) => {
                    setter(ref obj, reader, () => reader.ReadInt32());
                });
            } else if (type.BaseType.Name == "SerializableStruct`1") {
                var serializer = type.GetMethod("Serialize", new Type[] { typeof(BinaryWriter) });
                serializerSteps.Add((ref object obj, BinaryWriter writer) => {
                    var unref = obj;
                    getter(ref obj, writer, value => serializer.Invoke(value, new object[] { writer }));
                });

                var deserializer = type.BaseType.GetMethod("Deserialize", new Type[] { typeof(BinaryReader) });
                deserializerSteps.Add((ref object obj, BinaryReader reader) => {
                    setter(ref obj, reader, () => deserializer.Invoke(null, new object[] { reader }));
                });
            } else {
                return false;
            }

            return true;
        }
        private static void ParseSimple (FieldInfo field) {
            var parsed = ParseSimple(
                field.FieldType,
                (ref object obj, BinaryWriter writer, Action<object> cb) => cb(field.GetValue(obj)),
                (ref object obj, BinaryReader reader, Func<object> cb) => field.SetValue(obj, cb())
            );

            if (!parsed) ParseComplicated(field.FieldType, field);
        }

        public void Serialize (Stream stream) {
            Serialize(new BinaryWriter(stream));
        }
        public void Serialize (BinaryWriter writer) {
            object serializable = this;
            foreach (var step in serializerSteps) step(ref serializable, writer);
        }

        public static T Deserialize (Stream stream) {
            return Deserialize(new BinaryReader(stream));
        }
        public static T Deserialize (BinaryReader reader) {
            object deserializable = null;
            foreach (var step in deserializerSteps) step(ref deserializable, reader);
            return (T) deserializable;
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
