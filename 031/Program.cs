using System;
using System.Collections.Generic;
using System.Linq;

namespace _031 {
    class Program {
        static void Main(string[] args) {
            var numbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };


            //#1
            Console.WriteLine("-#1-----------");
            Console.WriteLine("8 or 9 mod. {0}", numbers.Exists(i => (i % 8 == 0) || (i % 9 == 0)));

            //#2
            Console.WriteLine("-#2-----------");
            numbers.ForEach(i => {
                Console.WriteLine("{0}={1}", i, (double)i / 2);
            });



            //#3
            Console.WriteLine("-#3-----------");
            var query = numbers.Where(i => i >= 50);
            foreach (var n in query) {
                Console.WriteLine(n);
            }

            //#4
            Console.WriteLine("-#4-----------");
            List<int> result = numbers.Select(i => i * 2).ToList();
            foreach (var n in result) {
                Console.WriteLine(n);
            }
        }
    }
}
