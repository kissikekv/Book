﻿using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    internal class BookListStorageFromCSV
    {
        private string _path;

        public BookListStorageFromCSV(string path)
        {
            Validator.ValidateFilePath(path);
            _path = path;
        }

        public void AddBook(Book book, bool append = true)
        {
            Validator.ValidateBookForNull(book);
            using (StreamWriter stwriter = new StreamWriter(_path, append))
            {
                stwriter.WriteLine(book.ISBN);
                stwriter.WriteLine(book.Author);
                stwriter.WriteLine(book.PublishingHouse);
                stwriter.WriteLine(book.PublishingYear);
                stwriter.WriteLine(book.Pages);
                stwriter.WriteLine(book.Cost);
            }

        }

        public Book? FindBookByISBN(string isbn)
        {
            if (!File.Exists(_path))
            {
                return default;
            }

            using (StreamReader sreader = new StreamReader(_path))
            {
                while (sreader.ReadLine() != null)
                {
                    var tempIsbn = sreader.ReadLine();
                    var tempAuthor = sreader.ReadLine();
                    var tempPublishingHouse = sreader.ReadLine();
                    var tempPublishingYear = sreader.ReadLine();
                    var tempPages = sreader.ReadLine();
                    var tempCost = sreader.ReadLine();
                    if (tempIsbn == isbn)
                    {
                        return new Book(
                            tempIsbn,
                            tempAuthor,
                            tempPublishingHouse,
                            Convert.ToInt32(tempPublishingYear),
                            Convert.ToInt32(tempPages),
                            Convert.ToDecimal(tempCost));
                    }
                }
                return default;
            }
        }

        public void DeleteBook(string? isbn)
        {
            List<Book> bookList = ReadBooks();
            var bookForDelete = bookList.FirstOrDefault(book => book.ISBN == isbn);
            Validator.ValidateBookForNull(bookForDelete);
            bookList.Remove(bookForDelete);
            RewriteFileWith(bookList);
        }

        public void Update(Book? book)
        {
            Validator.ValidateBookForNull(book);
            List<Book> bookList = ReadBooks();
            for (int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].ISBN == book.ISBN)
                {
                    bookList[i] = book;
                    break;
                }
            }

            RewriteFileWith(bookList);
        }

        private void RewriteFileWith(List<Book> bookList)
        {
            File.Delete(_path);
            foreach (Book item in bookList)
            {
                AddBook(item, true);
            }
        }

        private List<Book> ReadBooks()
        {
            List<Book> bookList = new List<Book>();

            using (StreamReader sreader = new StreamReader(_path))
            {
                while (sreader.ReadLine() != null)
                {
                    Book book1 = new Book(
                    sreader.ReadLine(),
                    sreader.ReadLine(),
                    sreader.ReadLine(),
                    Convert.ToInt32(sreader.ReadLine()),
                    Convert.ToInt32(sreader.ReadLine()),
                    Convert.ToDecimal(sreader.ReadLine()));
                    bookList.Add(book1);
                }
            }
            return bookList;
        }
    }
}

