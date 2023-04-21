using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;


namespace Book
{
    class Program
    {
        public class TestBook
        {
            public int Id { get; set; }
            public string Name { get; set; }            
        }
        public static void Main(string[] args)
        {
            Book book = new Book("978-5-699-12014-8", "Gandon", "Charlie Hebdo", 2001, 1488, 1.0M);
            Book book1 = new Book("978-5-699-12014-7", "DickHead", "Charlie Hebdo", 2001, 1337, 1.0M);
            Book book2 = new Book("978-5-699-12014-7", "Pedik", "Charlie Hebdo", 2001, 2012, 1.0M);

            List<Book> list = new List<Book>();

            list.Add(book);
            list.Add(book1);
            list.Add(book2);

            list.Sort();

            foreach (Book i in list)
            {
                Console.WriteLine(i.Author);
            }

            try
            {

            }

            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            TestBook testBook = new TestBook();

            Console.WriteLine(book1.Equals(book1)); //reflexive property

            Console.WriteLine(book.Equals(book1)); // symmetric property
            Console.WriteLine(book1.Equals(book));

            if (book.Equals(book1) && book1.Equals(book2))
            {
                Console.WriteLine($"aaaa {book.Equals(book2)} aaaa"); //transitive property
            }

            Console.WriteLine(book.Equals(book1));  // Successive invocations
            book1.Author = "Ksaicoc";
            Console.WriteLine("Ksaicoc");
            Console.WriteLine(book.Equals(book1));
            

            Console.WriteLine(book1.Equals(null));

            Console.WriteLine($"Any non-null value isn't equal to null {book1.Equals(testBook)}");
                    
            //book > book1(left > right)
            Console.WriteLine($" left > right {book > book1}");
            Console.WriteLine($" left >= right {book >= book1}");
            Console.WriteLine($" left < right {book < book1}");
            Console.WriteLine($" left <= right {book <= book1}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine($" left > right {book1 > book}");
            Console.WriteLine($" left >= right {book1 >= book}");
            Console.WriteLine($" left < right {book1 < book}");
            Console.WriteLine($" left <= right {book1 <= book}");
            Console.WriteLine("---------------------------------"); 
            Console.WriteLine($" left == right {book1 == book}");
            Console.WriteLine($" left != right {book1 != book}");
        }
    }
}