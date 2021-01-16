using System;
using System.Linq;

namespace _061 {
    class Program {
        static void Main(string[] args) {
            var numbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };
            Console.WriteLine("Max={0}", numbers.Max());
            var query = numbers.TakeLast(2);
            foreach (var item in query) {
                Console.WriteLine("TakeLast:{0}", item);
            }

            foreach (var item in numbers) {
                Console.WriteLine("toString:{0}", item.ToString());
            }

            query = numbers.OrderBy(n => n).Take(3);
            foreach (var item in query) {
                Console.WriteLine("small3:{0}", item);
            }

            var query2 = numbers.Distinct().Where(n => n > 10);
            Console.WriteLine("count:{0}", query2.Count());
            foreach (var item in query2) {
                Console.WriteLine("10over:{0}", item);
            }


        }
    }
}
