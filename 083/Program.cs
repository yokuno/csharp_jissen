using System;
using System.Text;

namespace _083 {
    class Program {
        static void Main(string[] args) {
            var tw = new TimeWatch();
            tw.Start();

            for (int i = 0; i < 200000; i++) {
                var sb = new StringBuilder();
                sb.Append("ABCDE");
            }

            TimeSpan duration = tw.Stop();
            Console.WriteLine("処理時間は{0}ミリ秒でした", duration.TotalMilliseconds);
        }
    }

    class TimeWatch {
        private DateTime dt;

        public void Start() {
            dt = DateTime.Now;
        }

        public TimeSpan Stop() {
            return DateTime.Now - dt;
        }
    }
}
