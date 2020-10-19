using System;
using System.Collections;
using System.IO;

namespace Common {
    public abstract class SerializableStruct<T> where T : SerializableStruct<T> {
        private delegate void Writer (BinaryWriter writer, object value);
        private delegate object Reader (BinaryReader reader);

        static SerializableStruct () {
            var type = typeof(T);
            foreach (var field in type.GetFields()) {
                var step = GetStep(field.FieldType);
                if (step == null) {
                    throw new Exception($"Field {field.Name} ({field.FieldType}) of {type.Name} not supported");
                }

                SerializeBaked += (object obj, BinaryWriter writer) => {
                    step.Write(writer, field.GetValue(obj));
                };

                DeserializeBaked += (object obj, BinaryReader reader) => {
                    field.SetValue(obj, step.Read(reader));
                };
            }
        }

        private static Action<object, BinaryWriter> SerializeBaked;
        public void Serialize (Stream stream) {
            Serialize(new BinaryWriter(stream));
        }
        public void Serialize (BinaryWriter writer) {
            SerializeBaked(this, writer);
        }

        private static Action<object, BinaryReader> DeserializeBaked;
        public static T Deserialize (Stream stream) {
            return Deserialize(new BinaryReader(stream));
        }
        public static T Deserialize (BinaryReader reader) {
            var instance = Activator.CreateInstance<T>();
            DeserializeBaked(instance, reader);
            return instance;
        }

        private class Step {
            public Reader Read;
            public Writer Write;
        }

        private static Step GetStep (Type type) {
            // Primitive types
            if (type == typeof(string)) {
                return new Step {
                    Write = (BinaryWriter writer, object value) => {
                        writer.Write((string) value);
                    },
                    Read = (BinaryReader reader) => {
                        return reader.ReadString();
                    }
                };
            } else if (type == typeof(float)) {
                return new Step {
                    Write = (BinaryWriter writer, object value) => {
                        writer.Write((float) value);
                    },
                    Read = (BinaryReader reader) => {
                        return reader.ReadSingle();
                    }
                };
            } else if (type == typeof(ulong)) {
                return new Step {
                    Write = (BinaryWriter writer, object value) => {
                        writer.Write((ulong) value);
                    },
                    Read = (BinaryReader reader) => {
                        return reader.ReadUInt64();
                    }
                };
            } else if (type == typeof(long)) {
                return new Step {
                    Write = (BinaryWriter writer, object value) => {
                        writer.Write((long) value);
                    },
                    Read = (BinaryReader reader) => {
                        return reader.ReadInt64();
                    }
                };
            } else if (type == typeof(uint)) {
                return new Step {
                    Write = (BinaryWriter writer, object value) => {
                        writer.Write((uint) value);
                    },
                    Read = (BinaryReader reader) => {
                        return reader.ReadUInt32();
                    }
                };
            } else if (type == typeof(int)) {
                return new Step {
                    Write = (BinaryWriter writer, object value) => {
                        writer.Write((int) value);
                    },
                    Read = (BinaryReader reader) => {
                        return reader.ReadInt32();
                    }
                };
            } else if (type == typeof(ushort)) {
                return new Step {
                    Write = (BinaryWriter writer, object value) => {
                        writer.Write((ushort) value);
                    },
                    Read = (BinaryReader reader) => {
                        return reader.ReadUInt16();
                    }
                };
            } else if (type == typeof(short)) {
                return new Step {
                    Write = (BinaryWriter writer, object value) => {
                        writer.Write((short) value);
                    },
                    Read = (BinaryReader reader) => {
                        return reader.ReadInt16();
                    }
                };
            } else if (type == typeof(double)) {
                return new Step {
                    Write = (BinaryWriter writer, object value) => {
                        writer.Write((double) value);
                    },
                    Read = (BinaryReader reader) => {
                        return reader.ReadDouble();
                    }
                };
            } else if (type == typeof(char)) {
                return new Step {
                    Write = (BinaryWriter writer, object value) => {
                        writer.Write((char) value);
                    },
                    Read = (BinaryReader reader) => {
                        return reader.ReadChar();
                    }
                };
            } else if (type == typeof(sbyte)) {
                return new Step {
                    Write = (BinaryWriter writer, object value) => {
                        writer.Write((sbyte) value);
                    },
                    Read = (BinaryReader reader) => {
                        return reader.ReadSByte();
                    }
                };
            } else if (type == typeof(byte)) {
                return new Step {
                    Write = (BinaryWriter writer, object value) => {
                        writer.Write((byte) value);
                    },
                    Read = (BinaryReader reader) => {
                        return reader.ReadByte();
                    }
                };
            } else if (type == typeof(bool)) {
                return new Step {
                    Write = (BinaryWriter writer, object value) => {
                        writer.Write((bool) value);
                    },
                    Read = (BinaryReader reader) => {
                        return reader.ReadBoolean();
                    }
                };
            } else if (type == typeof(decimal)) {
                return new Step {
                    Write = (BinaryWriter writer, object value) => {
                        writer.Write((decimal) value);
                    },
                    Read = (BinaryReader reader) => {
                        return reader.ReadDecimal();
                    }
                };
            } else if (type.BaseType == typeof(Enum)) {
                var baseType = Enum.GetUnderlyingType(type);
                var step = GetStep(baseType);
                if (step == null) {
                    throw new Exception($"Enum with type {baseType.Name} not supported");
                } else {
                    return step;
                }
                // Complicated types
            } else if (type.BaseType.Name == "SerializableStruct`1") {
                var serializer = type.GetMethod("Serialize", new Type[] { typeof(BinaryWriter) });
                var deserializer = type.BaseType.GetMethod("Deserialize", new Type[] { typeof(BinaryReader) });
                return new Step {
                    Write = (BinaryWriter writer, object value) => {
                        serializer.Invoke(value, new object[] { writer });
                    },
                    Read = (BinaryReader reader) => {
                        return deserializer.Invoke(null, new object[] { reader });
                    }
                };
            } else if (type.GetInterface("IList") != null) {
                var itemType = type.GetGenericArguments()[0];
                var itemStep = GetStep(itemType);
                if (itemStep == null) {
                    throw new Exception($"List of {itemType.Name} isn't supported");
                }

                return new Step {
                    Write = (BinaryWriter writer, object value) => {
                        var list = (IList) value;
                        writer.Write(list.Count);
                        foreach (var item in list) {
                            itemStep.Write(writer, item);
                        }
                    },
                    Read = (BinaryReader reader) => {
                        var list = (IList) Activator.CreateInstance(type);
                        var count = reader.ReadInt32();
                        for (var i = 0; i < count; i++) {
                            list.Add(itemStep.Read(reader));
                        }

                        return list;
                    }
                };
            } else if (type.GetInterface("IDictionary") != null) {
                var entryTypes = type.GetGenericArguments();

                var keyStep = GetStep(entryTypes[0]);
                if (keyStep == null) {
                    throw new Exception(entryTypes[0].Name + " as key type in dictionary isn't supported");
                }

                var valueStep = GetStep(entryTypes[1]);
                if (valueStep == null) {
                    throw new Exception(entryTypes[1].Name + " as value type in dictionary isn't supported");
                }

                return new Step {
                    Write = (BinaryWriter writer, object value) => {
                        var dictionary = (IDictionary) value;
                        writer.Write(dictionary.Count);
                        foreach (DictionaryEntry entry in dictionary) {
                            keyStep.Write(writer, entry.Key);
                            valueStep.Write(writer, entry.Value);
                        }
                    },
                    Read = (BinaryReader reader) => {
                        var dictionary = (IDictionary) Activator.CreateInstance(type);
                        var count = reader.ReadInt32();
                        for (var i = 0; i < count; i++) {
                            dictionary.Add(keyStep.Read(reader), valueStep.Read(reader));
                        }

                        return dictionary;
                    }
                };
            }

            return null;
        }
    }
}
