using System;
using System.Globalization;

namespace _081 {
    class Program {
        static void Main(string[] args) {
            var dt = DateTime.Now;

            Console.WriteLine(dt.ToString("yyyy/MM/dd HH:mm"));
            Console.WriteLine(dt.ToString("yyyy年MM月dd日 HH時mm分ss秒"));

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var era = culture.DateTimeFormat.Calendar.GetEra(dt);
            var eraName = culture.DateTimeFormat.GetEraName(era);

            var dayOfWeek = culture.DateTimeFormat.GetDayName(dt.DayOfWeek);


            Console.WriteLine("{0}({1})", dt.ToString("ggyy年 M月d日", culture),
                dayOfWeek);

            test2();
        }

        static void test2() {
            {
                var dt = new DateTime(2017, 1, 1);
                foreach (var dayofweek in Enum.GetValues(typeof(DayOfWeek))) {
                    Console.Write("{0:yy/MM/dd}の次週の{1}: ", dt, (DayOfWeek)dayofweek);
                    Console.WriteLine("{0:yy/MM/dd(ddd)}", NextWeek(dt, (DayOfWeek)dayofweek));
                }
            }
            Console.WriteLine();
            {
                var dt = new DateTime(2017, 4, 30);
                foreach (var dayofweek in Enum.GetValues(typeof(DayOfWeek))) {
                    Console.Write("{0:yy/MM/dd}の次週の{1}: ", dt, (DayOfWeek)dayofweek);
                    Console.WriteLine("{0:yy/MM/dd(ddd)}", NextWeek(dt, (DayOfWeek)dayofweek));
                }
            }
        }

        static DateTime NextWeek(DateTime dt, DayOfWeek dayOfWeek) {
            var nextweek = dt.AddDays(7);
            var days = (int)dayOfWeek - (int)(dt.DayOfWeek);
            return nextweek.AddDays(days);
        }
    }
}
