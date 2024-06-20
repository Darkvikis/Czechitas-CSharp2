using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ContactManager
{
    public static class XmlHelper
    {
        //V argumentech mame cestu k souboru a seznam kontaktu se kterymi pracujeme
        //Tuhle metodu muzeme volat pri ukonceni nebo pri pridani noveho kontaktu
        public static void ExportToXml(List<Contact> contacts, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Contact>));
            using TextWriter writer = new StreamWriter(filePath);
            serializer.Serialize(writer, contacts);
        }

        //Tady vracime seznam tech co jsme nacetli
        //Tuhle metodu muzeme volat i rovnou pri spousteni
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
