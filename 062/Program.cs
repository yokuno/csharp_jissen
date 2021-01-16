using System;
using System.Collections.Generic;
using System.Linq;

namespace _062 {
    class Program {
        static void Main(string[] args) {
            var books = new List<Book> {
               new Book { Title = "C#プログラミングの新常識", Price = 3800, Pages = 378 },
               new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
               new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
               new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
               new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
               new Book { Title = "私でも分かったASP.NET MVC", Price = 3200, Pages = 453 },
               new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
            };


            var r = books.FirstOrDefault(n => n.Title == "ワンダフル・C#ライフ");
            if (r != null) {
                Console.WriteLine("Price={0} Pages={1}", r.Price, r.Pages);
            }

            var cnt = books.Count(n => n.Title.Contains("C#"));
            Console.WriteLine("C#.count:{0}", cnt);

            var averagePages = books.Where(n => n.Title.Contains("C#")).Average(n => n.Pages);
            Console.WriteLine("Average pages in C#. {0}", averagePages);

            var first4000Book = books.FirstOrDefault(n => n.Price >= 4000);
            if (first4000Book != null) {
                Console.WriteLine("First 4000 yen book.{0}", first4000Book.Title);
            }

            var maxPagesBook = books.Where(n => n.Price < 4000).Max(n => n.Pages);
            Console.WriteLine("Max Pages over 4000 price:{0}", maxPagesBook);

            var query = books.Where(n => n.Pages >= 400).OrderByDescending(n => n.Price);
            foreach (var item in query) {
                Console.WriteLine("{0}={1}", item.Title, item.Price);
            }

            var query2 = books.Where(n => n.Title.Contains("C#") && (n.Pages >= 500));
            foreach (var item in query2) {
                Console.WriteLine("C# 500pages over:{0}", item.Title);
            }
        }
    }

    class Book {
        public string Title { get; set; }
        public int Price { get; set; }
        public int Pages { get; set; }
    }
}
