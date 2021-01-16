using System;
using System.Text.RegularExpressions;

namespace _101 {
    class Program {
        static void Main(string[] args) {
            while (true) {
                Console.WriteLine("input tel number:");
                var input = Console.ReadLine();
                Console.WriteLine("Is tel number:{0}", Regex.IsMatch(input, @"^0(7|8|9)0-(\d){3,4}-(\d){3,4}$"));
            }
        }
    }
}
