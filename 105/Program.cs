using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace _105 {
    class Program {
        static void Main(string[] args) {
            var path = @"c:\temp\hoge.html";
            TagLower(path);

            // これ以降は確認用
            var text = File.ReadAllText(path);
            Console.WriteLine(text);
        }

        static void TagLower(string file) {
            var lines = File.ReadLines(file);
            var sb = new StringBuilder();
            foreach (var line in lines) {
                var s = Regex.Replace(line,
                            @"<(/?)([A-Za-z]*)(.*?)>",
                            m => {
                                return string.Format("<{0}{1}{2}>", m.Groups[1].Value, m.Groups[2].Value.ToLower(), m.Groups[3].Value);
                            }
                        );
                sb.AppendLine(s);
            }
            File.WriteAllText(file, sb.ToString());
        }
    }
}

