using System;
using System.IO;
using System.Linq;

namespace _091 {
    class Program {
        static void Main(string[] args) {
            var csPath = @"C:\prj\research\C#\jissen\041\Program.cs";// @"C:\prj\research\C#\jissen\031\Program.cs";

            var cnt = 0;
            using (var reader = new StreamReader(csPath)) {

                while (!reader.EndOfStream) {
                    var line = reader.ReadLine();
                    if (line.Contains(" class ")) {
                        cnt++;
                    }
                }
            }
            Console.WriteLine("count:{0}", cnt);

            var cnt2 = File.ReadAllLines(csPath).Where(item => item.Contains(" class ")).Count();
            Console.WriteLine("count:{0}", cnt2);


            var cnt3 = File.ReadLines(csPath).Where(item => item.Contains(" class ")).Count();
            Console.WriteLine("count:{0}", cnt3);


        }
    }
}
