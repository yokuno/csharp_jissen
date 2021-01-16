using System;

namespace _023 {
    class Program {
        static void Main(string[] args) {
            var counter = new SalesCounter(@"C:\prj\research\C#\jissen\023\sale.csv");
            var amountPerCategory = counter.GetPerCategorySales();
            foreach (var obj in amountPerCategory) {
                Console.WriteLine("{0} {1}", obj.Key, obj.Value);
            }

            /*var amountPerStore = counter.GetPerStoreSales();
            foreach (var obj in amountPerStore) {
                Console.WriteLine("{0} {1}", obj.Key, obj.Value);
            }*/
        }
    }
}
