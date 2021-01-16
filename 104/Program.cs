using System.IO;
using System.Text.RegularExpressions;

namespace _104 {
    class Program {
        static void Main(string[] args) {
            var path = @"c:\temp\hoge.txt";
            var lines = File.ReadAllLines(path);
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.Read)) {
                stream.SetLength(0);
                stream.Position = 0;
                using (var writer = new StreamWriter(stream)) {
                    var re = new Regex(@"version(\s)*=(\s)*""v4\.0""", RegexOptions.IgnoreCase);
                    foreach (var item in lines) {
                        writer.WriteLine(re.Replace(item, @"version=""v5.0"""));
                    }
                }
            }
        }

    }
}
