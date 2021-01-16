using System;
using System.IO;
using System.Threading.Tasks;

namespace _161 {
    class Program {
        static void Main(string[] args) {
            AsyncMain().Wait();
        }

        static async Task AsyncMain() {
            using (var stream = new FileStream(@"c:\temp\hoge.txt", FileMode.Open, FileAccess.Read)) {
                using (var reader = new StreamReader(stream)) {
                    while (!reader.EndOfStream) {
                        var line = await reader.ReadLineAsync();
                        Console.WriteLine(line);
                    }
                }
            }
        }
    }
}
