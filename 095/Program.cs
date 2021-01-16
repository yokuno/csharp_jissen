using System;
using System.IO;
using System.Linq;

namespace _095 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Input directory path:");
            var dirPath = Console.ReadLine();

            var query = Directory.EnumerateFiles(dirPath).Where(item => {
                var fi = new FileInfo(item);
                return fi.Length >= 1024 * 1024;
            });
            foreach (var item in query) {
                Console.WriteLine(item);
            }
        }
    }
}
