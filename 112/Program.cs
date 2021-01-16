using System.Linq;
using System.Xml.Linq;

namespace _112 {
    class Program {
        public static object XDocuemnt { get; private set; }

        static void Main(string[] args) {
            var file = "Sample.xml";
            var doc = XDocument.Load(file);
            var query = doc.Root.Elements().Select(item => {
                return new XElement("word",
                    new XAttribute("kanji", item.Element("kanji").Value),
                    new XAttribute("yomi", item.Element("yomi").Value)
                );
            });
            var difficultKanji = new XElement("difficultkanji");
            foreach (var item in query) {
                difficultKanji.Add(item);
            }
            difficultKanji.Save(file + "_output.xml");


        }
    }
}
