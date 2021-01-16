using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _050 {
    class Program {
        static void Main(string[] args) {
            Console.Write("Input 1:");
            var input1 = Console.ReadLine();
            Console.Write("Input 2:");
            var input2 = Console.ReadLine();

            double number1;
            double number2;
            if (double.TryParse(input1, out number1)) {
                if (double.TryParse(input1, out number2)) {
                    Console.WriteLine("{0} {1}", number1, number2);
                }
            }

            var str = "Jackdaws Love my big sphinx of quartz";
            Console.WriteLine("Char count:{0}", str.Count());

            str = str.Replace("big", "small");
            Console.WriteLine(str);

            var words = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Word count:{0}", words.Length);

            var query = words.Where(n => n.Length > 3);
            foreach (var item in query) {
                Console.WriteLine(item);
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0, l = words.Length; i < l; i++) {
                sb.Append(words[i]);
                if (i < l - 1) {
                    sb.Append(" ");
                }
            }
            Console.WriteLine("stringbuilder result:{0}", sb.ToString());


            var str2 = "Novelist=谷崎;BestWork=春琴;Born=1886";
            var fields = new Dictionary<string, string> {
                {"Novelist","作家　"},
                {"BestWork","代表作"},
                {"Born","誕生年"},
            };

            var query2 = str2.Split(";").Select(n => n.Split("="));
            foreach (var item in query2) {
                Console.WriteLine("{0}:{1}", fields[item[0]], item[1]);
            }
        }
    }
}
