using System;
using System.Linq;
using System.Xml.Linq;

namespace _111 {
    class Program {
        static void Main(string[] args) {
            var file = "Sample.xml";
            var doc = XDocument.Load(file);
            var query = doc.Root.Elements();
            foreach (var item in query) {
                Console.WriteLine("{0}:{1}", item.Element("name").Value, (int)item.Element("teammembers"));
            }
            Console.WriteLine("=============");

            foreach (var item in doc.Root.Elements().OrderBy(item => (int)item.Element("firstplayed")).Select(item => item.Element("name").Attribute("kanji").Value)) {
                Console.WriteLine(item);
            }

            Console.WriteLine("=============");
            var res = doc.Root.Elements().OrderByDescending(item => (int)item.Element("teammembers")).FirstOrDefault();
            if (res != null) {
                Console.WriteLine(res.Element("name").Value);
            }


            Console.WriteLine("=============");
            var element = new XElement("ballsport",
                new XElement("name", "サッカー", new XAttribute("kanji", "蹴球")),
                new XElement("teammembers", 11),
                new XElement("firstplayed", 1863)
            );
            doc.Root.Add(element);
            doc.Save(file + ".output.xml");



            Console.WriteLine("=============");

        }
    }
}
