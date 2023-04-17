using System.Text.RegularExpressions;

namespace Book
{
    class Program
    {
        public static void Main(string[] args)
        {
            Book book = new Book();
            book.Author = "some Author";
            string author = book.Author;
            Console.WriteLine(author);

            book.ISBN = "978-3-16-148410-9";
            string isbn = book.ISBN;
            Console.WriteLine(isbn);

            book.Cost = 12313M;
            decimal cost = book.Cost;
            Console.WriteLine(cost);

            book.PublishingYear = 2025;
            int publishingYear = book.PublishingYear;
            Console.WriteLine(publishingYear);

            book.PublishingHouse = "Charlie Hebdo";
            string publishingHouse = book.PublishingHouse;
            Console.WriteLine(publishingHouse);

            book.Pages = 1;
            int pages = book.Pages;
            Console.WriteLine(pages);
            
            var c = new Regex("hui");
            Console.WriteLine(book.ToString());

            //ловить исключения try catch
            //override eq, getHash, ToString

        }
    }
}