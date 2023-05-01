using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

            list.Sort();
                     
            BookStorageFileRW bookStorageFileRW = new BookStorageFileRW();

            bookStorageFileRW.AddBook(book);
            bookStorageFileRW.AddBook(book1);
            bookStorageFileRW.AddBook(book2);
            bookStorageFileRW.DeleteBook("978-5-699-12014-8");
            bookStorageFileRW.Update(book2);
            
            
        }
    }
}
