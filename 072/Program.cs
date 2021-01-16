using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _072 {
    class Program {
        static void Main(string[] args) {
            var abbr = new Abbreviations();
            Console.WriteLine("{0}", abbr.Count);
            abbr.Remove("ILO");
            Console.WriteLine("{0}", abbr.Count);


            foreach (var item in abbr.Find3Addr()) {
                Console.WriteLine("{0}={1}", item.Key, item.Value);
            }
        }
    }

    class Abbreviations {
        private Dictionary<string, string> _dict = new Dictionary<string, string>();

        public Abbreviations() {
            var lines = File.ReadAllLines(@"C:\prj\research\C#\jissen\072\Abbreviations.txt");
            _dict = lines.Select(line => line.Split('='))
                .ToDictionary(item => item[0], item => item[1]);


        }

        public void Add(string addr, string japanese) {
            _dict[addr] = japanese;
        }

        public string this[string addr] {
            get {
                return _dict.ContainsKey(addr) ? _dict[addr] : null;
            }
        }

        public string ToAbbreviations(string japanese) {
            return _dict.FirstOrDefault(item => item.Value == japanese).Key;
        }

        public IEnumerable<KeyValuePair<string, string>> FindAll(string substring) {
            foreach (var item in _dict) {
                if (item.Value.Contains(substring)) {
                    yield return item;
                }
            }
        }

        public int Count {
            get {
                return _dict.Count;

            }
        }

        public bool Remove(string addr) {
            return _dict.Remove(addr);
        }


        public IEnumerable<KeyValuePair<string, string>> Find3Addr() {
            foreach (var item in _dict) {
                if (item.Key.Length == 3) {
                    yield return item;
                }
            }
        }
    }
}
