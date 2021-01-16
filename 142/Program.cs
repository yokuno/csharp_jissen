using System;
using System.Diagnostics;
using System.Reflection;

namespace _142 {
    class Program {
        static void Main(string[] args) {
            var asm = Assembly.GetExecutingAssembly();
            var ver = asm.GetName().Version;
            Console.WriteLine("Assembly.Version={0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Revision, ver.Build);

            var location = Assembly.GetExecutingAssembly().Location;
            var ver2 = FileVersionInfo.GetVersionInfo(location); //こちらの方法は任意pathのversionを取得
            Console.WriteLine("File.Version={0}.{1}.{2}.{3}", ver2.FileMajorPart, ver2.FileMinorPart, ver2.FileBuildPart, ver2.FilePrivatePart);




        }
    }
}
