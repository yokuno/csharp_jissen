using System;
using System.Collections.Generic;
using System.Linq;

namespace _071 {
    class Program {
        static void Main(string[] args) {
            func1();

            //func2();



        }

        private static void func1() {

            string input = "Cozy lummox gives smart squid who asks for job pen";
            var dict = new Dictionary<char, int>();
            foreach (var item in input) {

                var upper = Char.ToUpper(item);

                if ('A' <= upper && upper <= 'Z') {

                    if (dict.ContainsKey(upper)) {
                        dict[upper] += 1;
                    } else {
                        dict[upper] = 1;
                    }
                }
            }
            ;
            foreach (var item in doTest(dict)) {
                Console.WriteLine("{0}:{1}", item.Key, item.Value);
            }
        }

        private static IOrderedEnumerable<KeyValuePair<char, int>> doTest(IDictionary<char, int> dict) {
            // in句の後ろは関数を指定しても最初の１回しか呼ばれないことを確認。
            Console.WriteLine("hoge");
            return dict.OrderBy(item => item.Key);
        }

        private static void func2() {

            string input = "Cozy lummox gives smart squid who asks for job pen";
            var dict = new SortedDictionary<char, int>();
            foreach (var item in input) {

                var upper = Char.ToUpper(item);

                if ('A' <= upper && upper <= 'Z') {

                    if (dict.ContainsKey(upper)) {
                        dict[upper] += 1;
                    } else {
                        dict[upper] = 1;
                    }
                }
            }
            ;
            foreach (var item in dict) {
                Console.WriteLine("{0}:{1}", item.Key, item.Value);
            }
        }
    }
}
