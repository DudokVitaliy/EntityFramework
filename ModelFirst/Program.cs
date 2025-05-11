using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //    var context = new ModelFirstContainer()
            //            var usa = new country { country_name = "USA" };
            //            var ukraine = new country { country_name = "Ukraine" };
            //            var england = new country { country_name = "England" };
            //            context.countries.AddRange(new[] { usa, ukraine, england });

            //            var english = new language { language_name = "English", country = england };
            //            var ukrainian = new language { language_name = "Ukrainian", country = ukraine };
            //            var american = new language { language_name = "American", country = usa };
            //            context.languages.AddRange(new[] { english, ukrainian, american });

            //            var shakespeare = new author { author_name = "William", author_surname = "Shakespeare", age = 52 };
            //            var franko = new author { author_name = "Ivan", author_surname = "Franko", age = 60 };
            //            var twain = new author { author_name = "Mark", author_surname = "Twain", age = 74 };
            //            var rowling = new author { author_name = "Joanne", author_surname = "Rowling", age = 55 };
            //            context.authors.AddRange(new[] { shakespeare, franko, twain, rowling });

            //            context.books.AddRange(new[]
            //            {
            //                new book { book_name = "Hamlet", pages_count = 120, author = shakespeare, language = english },
            //                new book { book_name = "Othello", pages_count = 95, author = shakespeare, language = english },
            //                new book { book_name = "Faust", pages_count = 110, author = franko, language = ukrainian },
            //                new book { book_name = "Mykhas", pages_count = 80, author = franko, language = ukrainian },
            //                new book { book_name = "Tom Sawyer", pages_count = 150, author = twain, language = american },
            //                new book { book_name = "A Tale", pages_count = 105, author = twain, language = american },
            //                new book { book_name = "Azov", pages_count = 200, author = rowling, language = ukrainian },
            //                new book { book_name = "Art of Code", pages_count = 300, author = rowling, language = american }
            //});
            //            context.SaveChanges();    
            //    }


            var context = new ModelFirstContainer();

            Console.WriteLine("1");
            var q1 = context.books.Where(b => b.pages_count > 100);
            foreach (var b in q1) Console.WriteLine(b.book_name);

            Console.WriteLine("\n2");
            var q2 = context.books.Where(b => b.book_name.StartsWith("A") || b.book_name.StartsWith("a"));
            foreach (var b in q2) Console.WriteLine(b.book_name);

            Console.WriteLine("\n3");
            var q3 = context.books.Where(b => b.author.author_name == "William" && b.author.author_surname == "Shakespeare");
            foreach (var b in q3) Console.WriteLine(b.book_name);

            Console.WriteLine("\n4");
            var q4 = context.books.Where(b => b.language.language_name == "Ukrainian");
            foreach (var b in q4) Console.WriteLine(b.book_name);

            Console.WriteLine("\n5");
            var q5 = context.books.Where(b => b.book_name.Length < 10);
            foreach (var b in q5) Console.WriteLine(b.book_name);

            Console.WriteLine("\n6");
            var q6 = context.books
                .Where(b => b.language.language_name == "American")
                .OrderByDescending(b => b.pages_count)
                .FirstOrDefault();
            Console.WriteLine(q6?.book_name ?? "Not found!");

            Console.WriteLine("\n7");
            var q7 = context.authors
                .OrderBy(a => a.book.Count)
                .FirstOrDefault();
            Console.WriteLine($"{q7?.author_name} {q7?.author_surname} ({q7?.book.Count} books)");

            Console.WriteLine("\n8");
            var q8 = context.authors
                .Where(a => !a.book.Any(b => b.language.language_name == "American"))
                .OrderBy(a => a.author_name);
            foreach (var a in q8) Console.WriteLine($"{a.author_name} {a.author_surname}");

            Console.WriteLine("\n9");
            var q9 = context.countries
                .OrderByDescending(c => c.language.SelectMany(l => l.book).Count()) 
                .FirstOrDefault();
           Console.WriteLine(q9?.country_name ?? "Not found!");



            Console.WriteLine("\n10");
            var q10 = context.authors
                .Where(a => a.book.Select(b => b.language).Distinct().Count() > 1)
                .OrderByDescending(a => a.book.Select(b => b.language).Distinct().Count());

            foreach (var a in q10)
            {
                var count = a.book.Select(b => b.language).Distinct().Count();
                Console.WriteLine($"{a.author_name} {a.author_surname} - {count} languages");
            }

        }
    }
}
