using System;

namespace _022 {
    class Program {
        static void Main(string[] args) {
            const double rate = 0.0254;
            for (int i = 1, l = 10; i <= l; i++) {
                Console.WriteLine("{0}インチ = {1}メートル", i, i * rate);

            }
        }
    }
}
