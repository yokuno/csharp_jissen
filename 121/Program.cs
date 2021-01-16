using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Serialization;

namespace _121 {
    class Program {
        static void Main(string[] args) {
            var v = new Employee { Id = 123, Name = "山田太郎", HireDate = DateTime.Now };

            using (var writer = XmlWriter.Create("out.xml")) {
                var serializer = new XmlSerializer(v.GetType());
                serializer.Serialize(writer, v);
            }

            var list = new List<Employee> { };
            list.Add(new Employee { Id = 123, Name = "山田太郎", HireDate = DateTime.Now });
            list.Add(new Employee { Id = 124, Name = "a山田太郎", HireDate = DateTime.Now });
            list.Add(new Employee { Id = 125, Name = "b山田太郎", HireDate = DateTime.Now });
            list.Add(new Employee { Id = 126, Name = "c山田太郎", HireDate = DateTime.Now });

            using (var writer = XmlWriter.Create("out2.xml")) {
                var serializer = new DataContractSerializer(list.GetType());
                serializer.WriteObject(writer, list);
            }

            var inList = new List<Employee> { };
            using (var reader = XmlReader.Create("out2.xml")) {
                var serializer = new DataContractSerializer(list.GetType());
                inList = serializer.ReadObject(reader) as List<Employee>;
            }
            foreach (var item in inList) {
                Console.WriteLine("{0}", item.Name);
            }

            using (var file = new FileStream("out.json", FileMode.Create, FileAccess.Write, FileShare.None)) {
                var serializer = new DataContractJsonSerializer(list.GetType());
                serializer.WriteObject(file, list);
            }


        }
    }

    public class Employee {
        [IgnoreDataMember]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime HireDate { get; set; }
    }
}
