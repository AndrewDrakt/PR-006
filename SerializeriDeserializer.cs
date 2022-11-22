using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Практ6
{
    internal class SerializeriDeserializer
    {
        public static void SerialJson(Fele subject, string way)
        {
            string json = JsonConvert.SerializeObject(subject);
            File.WriteAllText(way, json);
        }
        public static void SerializeXML(Fele subject, string way)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Fele));
            using (FileStream dd = new FileStream(way, FileMode.OpenOrCreate))
            {
                xml.Serialize(dd, subject);
            }
        }
        public static void Deserialize(string way)
        {
            Fele vivod;
            XmlSerializer xml = new XmlSerializer(typeof(Fele));
            using (FileStream dd = new FileStream(way, FileMode.OpenOrCreate))
            {
                vivod = (Fele)xml.Deserialize(dd);
            }
        }
        public static void ЖысонДириализе(string put)
        {
            string text = File.ReadAllText(put);
            List<Fele> tekst = JsonConvert.DeserializeObject<List<Fele>>(text);
        }
    }
}
