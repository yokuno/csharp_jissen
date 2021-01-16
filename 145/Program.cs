using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace _145 {
    class Program {
        static void Main(string[] args) {
            var path = args[0];
            var outdir = args[1];
            if (!Directory.Exists(outdir)) {
                Directory.CreateDirectory(outdir);
            }

            using (var zip = ZipFile.OpenRead(path)) {
                foreach (var item in zip.Entries.Where(item => item.Name.EndsWith(".json", StringComparison.OrdinalIgnoreCase))) {
                    item.ExtractToFile(Path.Combine(outdir, item.FullName));
                }
            }
        }
    }
}
