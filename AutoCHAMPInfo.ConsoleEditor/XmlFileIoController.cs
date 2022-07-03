using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace TypeAutoCHAMP
{
    public class XmlFileIoController {

        public void Save(DataSet dataSet, string fileName) {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.Unicode;
            XmlWriter writer = null;
            try {
                writer = XmlWriter.Create(fileName, settings);
                WriteData(dataSet, writer);
            }
            catch (Exception) {
                throw;
            }
            finally {
                if (writer != null)
                    writer.Close();
            }
        }

        void WriteData(DataSet dataSet, XmlWriter writer) {
            writer.WriteStartDocument();
            writer.WriteStartElement("TypeRentsInfo");
            WriteRent(dataSet.Class, writer);
            WriteTypeRents(dataSet.TypeClass, writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
        }

        void WriteRent(IEnumerable<Class> collection, XmlWriter writer) {
            writer.WriteStartElement("ClassData");
            foreach (var inst in collection) {
                writer.WriteStartElement("Class");
                writer.WriteElementString("Id", inst.Id.ToString());
                writer.WriteElementString("Name", inst.name);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        private void WriteTypeRents(IEnumerable<TypeClass> collection, XmlWriter writer) {
            writer.WriteStartElement("TypeClassData");
            foreach (var inst in collection) {
                writer.WriteStartElement("TypeClass");
                writer.WriteElementString("Id", inst.Id.ToString());
                writer.WriteElementString("Carmodel", inst.Carmodel);
                int ClassId = inst.Class == null ? 0 : inst.Class.Id;
                writer.WriteElementString("ClassId", ClassId.ToString());
                writer.WriteElementString("nameperson", inst.nameperson);
                writer.WriteElementString("prize", inst.prize.ToString());
                writer.WriteElementString("Commandname", inst.Commandname.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }


        //-----------------------------------------------------------

        public void Load(DataSet dataSet, string fileName) {
            if (!File.Exists(fileName)) return;

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            using (XmlReader reader = XmlReader.Create(fileName, settings)) {
                while (reader.Read()) {
                    if (reader.NodeType == XmlNodeType.Element) {
                        switch (reader.Name) {
                            case "Class":
                                ReadClass(reader, dataSet.Class);
                                break;
                            case "TypeClass":
                                ReadTypeClass(reader, dataSet);
                                break;
                        }
                    }
                }
            }
        }

        void ReadClass(XmlReader reader, ICollection<Class> collection) {
            reader.ReadStartElement("Class");
            int id = reader.ReadElementContentAsInt();
            string name = reader.ReadElementContentAsString();
            Class inst = new Class(name) { Id = id };
            collection.Add(inst);
        }

        void ReadTypeClass(XmlReader reader, DataSet dataSet) {
            TypeClass inst = new TypeClass();
            reader.ReadStartElement("TypeClass");
            inst.Id = reader.ReadElementContentAsInt();
            inst.Carmodel = reader.ReadElementContentAsString();
            int ClassId = reader.ReadElementContentAsInt();
            inst.Class = dataSet.Class
                .FirstOrDefault(e => e.Id == ClassId);
            inst.nameperson = reader.ReadElementContentAsString();
            string s = reader.ReadElementContentAsString();
            inst.prize = string.IsNullOrEmpty(s)
                ? (double?)null : double.Parse(s);
            inst.Commandname = reader.ReadElementContentAsString();
            dataSet.TypeClass.Add(inst);
        }

    }
}
