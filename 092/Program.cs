using System;
using System.IO;
using System.Text;

namespace _092 {
    class Program {
        static void Main(string[] args) {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var inputPath = @"c:\temp\hoge.txt";
            var outputPath = Path.GetTempFileName();

            using (var input = new StreamReader(inputPath, encoding: Encoding.GetEncoding("shift_jis"))) {
                using (var output = new StreamWriter(outputPath)) {
                    var idx = 0;
                    while (!input.EndOfStream) {
                        output.WriteLine(String.Format("{0}:{1}", idx + 1, input.ReadLine()));
                        idx++;
                    }
                }
            }
            Console.WriteLine(outputPath);
        }
    }
}
