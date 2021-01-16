using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _162 {
    class Program {
        static void Main(string[] args) {
            //Console.WriteLine("Input directory");
            //var dir = Console.ReadLine();

            //var dir = @"c:\prj\research\C#";
            var dir = @"C:\prj\research\wopi";

            var asyncRegEx = new Regex(@"\s[async|await]\s");

            var dt = DateTime.Now;
            Console.WriteLine("Start:sync mode");
            SearchDirectory(dir, asyncRegEx);
            var syncTimeSpan = DateTime.Now - dt;

            dt = DateTime.Now;
            Console.WriteLine("Start:async mode");
            AsyncSearchDirectory(dir, asyncRegEx).Wait();
            var asyncTimeSpan = DateTime.Now - dt;

            Console.WriteLine("sync:{0}", syncTimeSpan.ToString(@"mm\:ss\.ff"));
            Console.WriteLine("async:{0}", asyncTimeSpan.ToString(@"mm\:ss\.ff"));

        }

        static void SearchDirectory(string dir, Regex asyncRegEx) {
            var query = Directory.GetFiles(dir)
                    .Where(file => Path.GetExtension(file).ToLower() == ".cs");

            foreach (var csPath in query) {
                foreach (var line in File.ReadAllLines(csPath)) {
                    if (asyncRegEx.IsMatch(line)) {
                        Console.WriteLine(csPath);
                    }
                }
            }
            foreach (var subdir in Directory.GetDirectories(dir)) {
                SearchDirectory(subdir, asyncRegEx);
            }
        }



        static async Task AsyncSearchDirectory(string dir, Regex asyncRegEx) {
            var files = Directory.GetFiles(dir)
                    .Where(file => Path.GetExtension(file).ToLower() == ".cs").ToArray();


            var idx = 0;
            var tasks = new Task[files.Length];
            foreach (var csPath in files) {
                tasks[idx] = Task.Run(() => {
                    foreach (var line in File.ReadAllLines(csPath)) {
                        if (asyncRegEx.IsMatch(line)) {
                            Console.WriteLine(csPath);
                        }
                    }
                });
                idx++;
            }
            await Task.WhenAll(tasks);

            foreach (var subdir in Directory.GetDirectories(dir)) {
                SearchDirectory(subdir, asyncRegEx);
            }
        }

    }
}
