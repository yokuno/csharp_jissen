using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _173 {
    class Program {
        static void Main(string[] args) {
            var tp = new TextFileProcessor(new ZenToHanConverter());
            tp.Run(@"c:\temp\hoge.txt");
        }
    }

    public class ZenToHanConverter : ITextFileService {
        private Dictionary<char, char> conv = new Dictionary<char, char>() {
            {'１','1'},{'２','2'},{'３','3'},{'４','4'},{'５','5'},
            {'６','6'},{'７','7'},{'８','8'},{'９','9'},{'０','0'},
            {'Ａ','A'},{'Ｂ','B'},{'Ｃ','C'},{'Ｄ','D'},{'Ｅ','E'},
            {'Ｆ','F'},{'Ｇ','G'},{'Ｈ','H'},{'Ｉ','I'},{'Ｊ','J'},
            {'Ｋ','K'},{'Ｌ','L'},{'Ｍ','M'},{'Ｎ','N'},{'Ｏ','O'},
            {'Ｐ','P'},{'Ｑ','Q'},{'Ｒ','R'},{'Ｓ','S'},{'Ｔ','T'},
            {'Ｕ','U'},{'Ｖ','V'},{'Ｗ','W'},{'Ｘ','X'},{'Ｙ','Y'},
            {'Ｚ','Z'},
            {'ａ','a'},{'ｂ','b'},{'ｃ','c'},{'ｄ','d'},{'ｅ','e'},
            {'ｆ','f'},{'ｇ','g'},{'ｈ','h'},{'ｉ','i'},{'ｊ','j'},
            {'ｋ','k'},{'ｌ','l'},{'ｍ','m'},{'ｎ','n'},{'ｏ','o'},
            {'ｐ','p'},{'ｑ','q'},{'ｒ','r'},{'ｓ','s'},{'ｔ','t'},
            {'ｕ','u'},{'ｖ','v'},{'ｗ','w'},{'ｘ','x'},{'ｙ','y'},
            {'ｚ','z'},
            {'　',' '},
         };

        public void Initialize(string fName) {
            //nothing to do
        }

        public void Execute(string line) {

            string s = new string(line.Select(n => (conv.ContainsKey(n) ? conv[n] : n)).ToArray());
            Console.WriteLine(s);

        }

        public void Terminate() {
            //nothing to do
        }
    }


    public interface ITextFileService {
        void Initialize(string fName);
        void Execute(string line);
        void Terminate();
    }

    public class TextFileProcessor {
        private ITextFileService _service;

        public TextFileProcessor(ITextFileService service) {
            _service = service;
        }

        public void Run(string fileName) {
            _service.Initialize(fileName);
            using (var sr = new StreamReader(fileName)) {
                while (!sr.EndOfStream) {
                    string line = sr.ReadLine();
                    _service.Execute(line);
                }
            }
            _service.Terminate();
        }
    }
}
