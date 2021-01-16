using System;
using System.IO;
using System.Text.RegularExpressions;

namespace _102 {
    class Program {
        static void Main(string[] args) {
            var lines = File.ReadLines(@"c:\temp\hoge.txt");
            var re = new Regex(@"\d{3,}");
            foreach (var item in lines) {
                foreach (Match m in re.Matches(item)) {
                    Console.WriteLine(m.Value);
                }
            }

        }
    }
}
