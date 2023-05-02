using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.PortableExecutable;
using Book.Exceptions;

namespace Book
{
    internal class BookStorageFileRW
    {
        private string _path;   

        public BookStorageFileRW(string path)
        {
            _path = path;  //валидотор пути          
        }        

        public void AddBook(Book? book)
        {
            ValidateBookForNull(book);

            using (var writer = new BinaryWriter(File.Open(_path, FileMode.Append)))
            {
                writer.Write(book.ISBN);
                writer.Write(book.Author);
                writer.Write(book.PublishingHouse);
                writer.Write(book.PublishingYear);
                writer.Write(book.Pages);
                writer.Write(book.Cost);
            }
        }

        public Book? FindBookByISBN(string? isbn)
        {
            if (!File.Exists(_path))
            {
                return default;
            }

            using (var reader = new BinaryReader(File.Open(_path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    var tempIsbn = reader.ReadString();
                    var tempAuthor = reader.ReadString();
                    var tempPublishingHouse = reader.ReadString();
                    var tempPublishingYear = reader.ReadInt32();
                    var tempPages = reader.ReadInt32();
                    var tempCost = reader.ReadDecimal();

                    if (tempIsbn == isbn)
                    {
                        return new Book(tempIsbn,
                            tempAuthor,
                            tempPublishingHouse,
                            tempPublishingYear,
                            tempPages,
                            tempCost);
                    }
                }
                return default;
            }
        }

        public void DeleteBook(string? isbn)
        {
            List<Book> bookList = ReadBooks();                        
            var bookForDelete = bookList.FirstOrDefault(book => book.ISBN == isbn);
            ValidateBookForNull(bookForDelete);
            bookList.Remove(bookForDelete);
            RewriteFileWith(bookList);
        }

        public void Update(Book? book)
        {
            ValidateBookForNull(book);
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

        private static void ValidateBookForNull(Book? book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException(nameof(book));
            }
        }

        private void RewriteFileWith(List<Book> bookList)
        {
            File.Delete(_path);
            foreach (Book item in bookList)
            {
                AddBook(item);
            }
        }

        private List<Book> ReadBooks()
        {    
            List<Book> bookList = new List<Book>();

            using (var reader = new BinaryReader(File.Open(_path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    Book book1 = new Book(
                    reader.ReadString(),
                    reader.ReadString(),
                    reader.ReadString(),
                    reader.ReadInt32(),
                    reader.ReadInt32(),
                    reader.ReadDecimal());
                    bookList.Add(book1);
                }
            }

            return bookList;
        }
    }
}
