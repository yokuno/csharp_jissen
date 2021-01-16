using _131_netframework.Models;
using System;
using System.Linq;

namespace _131_netframework {
    class Program {
        static void Main(string[] args) {
            //InsertBooks();
            //ShowBooks();
            //ShowMaxLengthTitleBook();
            //ShowOldPublished3Books();

            ShowBooks2();

            Console.ReadLine();
        }

        static void ShowBooks2() {
            using (var db = new BooksDbContext()) {
                var query = db.Books
                    .Join(db.Author,
                        (b) => b.Author.Id,
                        (a) => a.Id,
                        (b, a) => new { Birthday = a.Birthday, PublishedYear = b.PublishedYear, Title = b.Title, Author = a.Name })
                    .OrderBy(item => item.Birthday)
                    .ThenBy(item => item.PublishedYear);


                var prevAuthor = "";
                foreach (var item in query) {
                    if (prevAuthor != item.Author) {
                        Console.WriteLine("[Author]{0}", item.Author);
                        prevAuthor = item.Author;
                    }
                    Console.WriteLine("    {0}:{1}", item.PublishedYear, item.Title);
                }

            }
        }

        static void ShowOldPublished3Books() {
            using (var db = new BooksDbContext()) {
                var query = db.Books
                    .Join(db.Author,
                        (b) => b.Author.Id,
                        (a) => a.Id,
                        (b, a) => new { PublishedYear = b.PublishedYear, Title = b.Title, Author = a.Name })
                    .OrderBy(item => item.PublishedYear).Take(3);


                foreach (var item in query) {
                    Console.WriteLine("{0}:{1}:{2}", item.PublishedYear, item.Title, item.Author);
                }

            }
        }


        static void ShowMaxLengthTitleBook() {
            using (var db = new BooksDbContext()) {
                var len = db.Books.OrderByDescending(item => item.Title.Length).First().Title.Length;
                var query = db.Books.Where(item => item.Title.Length == len);

                foreach (var item in query) {
                    Console.WriteLine("len={0}, title={1}", item.Title.Length, item.Title);
                }
            }
        }

        static void ShowBooks() {
            using (var db = new BooksDbContext()) {
                var query = db.Books.Join(db.Author,
                    (b) => b.Author.Id,
                    (a) => a.Id,
                    (b, a) => new { Title = b.Title, Author = a.Name });

                foreach (var item in query) {
                    Console.WriteLine("{0}:{1}", item.Title, item.Author);
                }

            }
        }

        static void InsertBooks() {
            using (var db = new BooksDbContext()) {
                /*                var book1 = new Book {
                                    Title = "坊ちゃん",
                                    PublishedYear = 2003,
                                    Author = new Author {
                                        Birthday = new DateTime(1867, 2, 9),
                                        Gender = "M",
                                        Name = "夏目 漱石"
                                    }
                                };
                                db.Books.Add(book1);

                                var book2 = new Book {
                                    Title = "人間失格",
                                    PublishedYear = 1990,
                                    Author = new Author {
                                        Birthday = new DateTime(1909, 6, 19),
                                        Gender = "M",
                                        Name = "太宰 治"
                                    }
                                };
                                db.Books.Add(book2);
                                db.SaveChanges();*/

                var authorKikuchi = new Author {
                    Birthday = new DateTime(1888, 12, 26),
                    Gender = "M",
                    Name = "菊池 寛"
                };
                db.Author.Add(authorKikuchi);

                var authorKawabata = new Author {
                    Birthday = new DateTime(1899, 6, 14),
                    Gender = "M",
                    Name = "川端 康成"
                };
                db.Author.Add(authorKawabata);

                var authorMiyazawa = new Author {
                    Birthday = new DateTime(1896, 8, 27),
                    Gender = "M",
                    Name = "宮沢 賢治"
                };
                db.Author.Add(authorMiyazawa);


                var authorNatume = db.Author.Single(item => item.Name.Contains("夏目"));


                db.Books.Add(new Book {
                    Title = "こころ",
                    PublishedYear = 1991,
                    Author = authorNatume
                });


                db.Books.Add(new Book {
                    Title = "伊豆の踊子",
                    PublishedYear = 2003,
                    Author = authorKawabata
                });



                db.Books.Add(new Book {
                    Title = "真珠夫人",
                    PublishedYear = 2002,
                    Author = authorKikuchi
                });



                db.Books.Add(new Book {
                    Title = "注文の多い料理店",
                    PublishedYear = 2000,
                    Author = authorMiyazawa
                });



                db.SaveChanges();


            }
        }
    }
}
