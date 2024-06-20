using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ContactManager
{
    public static class XmlHelper
    {
        public static void ExportToXml(List<Contact> contacts, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Contact>));
            using (TextWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, contacts);
            }
        }

        public static List<Contact> ImportFromXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Contact>));
            using (TextReader reader = new StreamReader(filePath))
            {
                return (List<Contact>)serializer.Deserialize(reader);
            }
        }
    }
}
