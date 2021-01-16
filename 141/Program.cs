using System;
using System.Diagnostics;
using System.IO;

namespace _141 {
    class Program {
        static void Main(string[] args) {
            foreach (var item in File.ReadLines("processlist.txt")) {
                Console.WriteLine(item);
                using (var process = Process.Start(item)) {
                    
                    if (process.WaitForExit(1000000)) {

                    }
                }
            }
            Console.ReadLine();
        }
    }
}
