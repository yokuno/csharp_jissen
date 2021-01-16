using System;
using System.IO;

namespace _093 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("input:");
            var inputPath = Console.ReadLine();
            Console.WriteLine("output:");
            var outputPath = Console.ReadLine();

            using (var reader = new StreamReader(inputPath)) {
                using (var writer = new StreamWriter(outputPath, append: true)) {
                    while (!reader.EndOfStream) {
                        var line = reader.ReadLine();
                        writer.WriteLine(line);
                    }
                }
            }

        }
    }
}
