using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Serialization;

namespace _122 {
    class Program {
        static void Main(string[] args) {
            var noveList = new NoveList();
            using (var reader = XmlReader.Create("Sample.xml")) {
                var serializer = new XmlSerializer(noveList.GetType());
                noveList = serializer.Deserialize(reader) as NoveList;
            }
            Console.WriteLine(noveList.Name);

            using (var stream = new FileStream("out.json", FileMode.Create, FileAccess.Write, FileShare.None)) {
                var settings = new DataContractJsonSerializerSettings();
                settings.DateTimeFormat = new DateTimeFormat(@"yyyy-MM-dd'T'HH:mm:ssZ");
                var serializer = new DataContractJsonSerializer(noveList.GetType(), settings);
                serializer.WriteObject(stream, noveList);
            }
        }
    }


    [DataContract(Name = "novelist")]
    [XmlRoot("novelist")]
    public class NoveList {
        [DataMember(Name = "name")]
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [DataMember(Name = "birth")]
        [XmlElement(ElementName = "birth")]
        public DateTime Birth { get; set; }

        [DataMember(Name = "masterpieces")]
        [XmlArray("masterpieces")]
        [XmlArrayItem("title", typeof(string))]
        public string[] Masterpieces { get; set; }
    }
}
