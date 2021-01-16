using System;
using System.Text.RegularExpressions;

namespace _103 {
    class Program {
        static void Main(string[] args) {
            var texts = new[] {
               "Time is money.",
               "What time is it?",
               "It will take time.",
               "We reorganized the timetable.",
            };

            var re = new Regex(@"\btime\b", RegexOptions.IgnoreCase);
            foreach (var item in texts) {
                foreach (Match m in re.Matches(item)) {
                    Console.WriteLine("{0}:{1}", item, m.Index);
                }
            }
        }
    }
}
