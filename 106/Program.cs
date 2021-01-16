using System;
using System.Text.RegularExpressions;

namespace _106 {
    class Program {
        static void Main(string[] args) {
            var text = "しるし しんぶんし きたのたき きもの いろしろい トマト ヨクナクヨ";
            var pattern = @"\b(\w)(\w)\w\2\1\b";
            var matches = Regex.Matches(text, pattern);
            foreach (Match m in matches)
                Console.WriteLine("'{0}'", m.Value);
        }
    }
}
