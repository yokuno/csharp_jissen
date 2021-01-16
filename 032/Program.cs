using System;
using System.Collections.Generic;
using System.Linq;

namespace _032 {
    class Program {
        static void Main(string[] args) {

            var names = new List<string>{
                "Tokyo","New Delhi","Bangkok","London","Paris","Berlin","Canberra","Hong Kong"
            };

            Console.WriteLine("=#1==========================");
            Console.WriteLine("Please input city name:");
            string inputCity = Console.ReadLine();
            var idx = names.FindIndex(n => n == inputCity);
            Console.WriteLine(idx);



            Console.WriteLine("=#2==========================");
            var count = names.Count((string n) => {
                return n.Contains("o");
            });
            Console.WriteLine("count={0}", count);


            Console.WriteLine("=#3==========================");
            var list = names.Where(n => n.Contains("o")).ToList();
            foreach (var n in list) {
                Console.WriteLine(n);
            }


            Console.WriteLine("=#4==========================");
            var query = names.Where(n => n.StartsWith("B")).Select(n => n.Length);
            foreach (var n in query) {
                Console.WriteLine(n);
            }

        }
    }
}
