using System;
using System.Collections.Generic;
using System.Linq;

namespace _041 {
    class Program {


        static void Main(string[] args) {


            Console.WriteLine("==#42.1====================");
            var list = new List<YearMonth> {
                new YearMonth(1900, 1),
                new YearMonth(2000, 2),
                new YearMonth(2100, 12),
                new YearMonth(1999, 4),
                new YearMonth(2099, 5),
            };


            Console.WriteLine("==#42.2====================");
            var idx = 0;
            list.ForEach(n => {
                Console.WriteLine("list[{0}]=Year={1}, Month={2}", idx, n.Year, n.Month);
                idx++;
            });


            Console.WriteLine("==#42.4====================");
            var century = Find21Century(list);
            if (century != null) {
                Console.WriteLine("Firts 21 century.Year={0}, Month={1}", century.Year, century.Month);
            } else {
                Console.WriteLine("21世紀のデータはありません");
            }

            Console.WriteLine("==#42.5====================");
            var query = list.Select(n => n.AddOneMonth()).OrderBy(n => n.Year).ThenBy(n => n.Month);
            idx = 0;
            foreach (var item in query) {
                Console.WriteLine("list[{0}]=Year={1}, Month={2}", idx, item.Year, item.Month);
                idx++;
            }



        }

        static YearMonth Find21Century(List<YearMonth> list) {
            Console.WriteLine("==#42.3====================");
            foreach (var n in list) {
                if (n.Is21Century()) {
                    return n;
                }

            }
            return null;
        }

        class YearMonth {
            public int Year { get; private set; }
            public int Month { get; private set; }



            public YearMonth(int year, int month) {
                Year = year;
                Month = month;
            }

            public Boolean Is21Century() {
                return (2000 <= Year) && (Year < 2100);
            }

            public YearMonth AddOneMonth() {
                var newMonth = Month + 1;
                var newYear = Year;
                if (newMonth > 12) {
                    newYear++;
                    newMonth -= 12;
                }

                return new YearMonth(newYear, newMonth);
            }

            public override string ToString() {
                return String.Format("{0}年{1}日", Year, Month);
            }
        }
    }
}
