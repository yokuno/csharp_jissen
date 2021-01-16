using System;
using System.IO;

namespace _094 {
    class Program {
        static void Main(string[] args) {
            var dirPath = @"C:\temp\Scan";
            var outDirPath = @"c:\temp\Copy";

            if (!Directory.Exists(outDirPath))
                Directory.CreateDirectory(outDirPath);

            foreach (var item in Directory.EnumerateFiles(dirPath)) {
                var newPath = Path.Combine(outDirPath, Path.GetFileNameWithoutExtension(item) + "_bak" + Path.GetExtension(item));
                Console.WriteLine(newPath);
                File.Copy(item, newPath, overwrite: true);
            }



        }
    }
}
