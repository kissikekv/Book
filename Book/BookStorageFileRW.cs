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
        private string _path = "E:\\EduBlya\\file.dat";
        List<Book> _bookList = new List<Book>();

        public void AddBook(Book? book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException(nameof(book));
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(_path, FileMode.Append)))
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
            using (var reader = new BinaryReader(File.Open(_path, FileMode.Open)))
            {
                if (reader.PeekChar() == -1)
                {
                    throw new ArgumentException(nameof(reader));
                }

                while (reader.PeekChar() > -1)
                {
                    if (reader.ReadString() == isbn)
                    {
                        var book = new Book(
                        isbn,
                        reader.ReadString(),
                        reader.ReadString(),
                        reader.ReadInt32(),
                        reader.ReadInt32(),
                        reader.ReadDecimal());
                        return book;
                    }

                    reader.ReadString();
                    reader.ReadString();
                    reader.ReadInt32();
                    reader.ReadInt32();
                    reader.ReadDecimal();
                }

                return default;
            }
        }

        public void DeleteBook(string? isbn)
        {
            using (var reader = new BinaryReader(File.Open(_path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    Book book = new Book(
                    reader.ReadString(),
                    reader.ReadString(),
                    reader.ReadString(),
                    reader.ReadInt32(),
                    reader.ReadInt32(),
                    reader.ReadDecimal());
                    _bookList.Add(book);
                }
            }

            var bookForDelete = FindBookByISBN(isbn);

            if (ReferenceEquals(bookForDelete, null))
            {
                return;
            }

            _bookList.Remove(bookForDelete);

            using (FileStream fileStream = new FileStream(_path, FileMode.OpenOrCreate))
            {
                lock (fileStream)
                {
                    fileStream.SetLength(0);
                }
            }

            foreach (Book book in _bookList)
            {
                AddBook(book);
            }

            _bookList.Clear();
        }

        public void Update(Book? book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException(nameof(book));
            }

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
                    _bookList.Add(book1);
                }
            }            

            for (int i = 0; i < _bookList.Count; i++)
            {
                if (_bookList[i].ISBN == book.ISBN)
                {
                    _bookList[i] = book;
                    break;
                }
            }

            using (FileStream fileStream = new FileStream(_path, FileMode.OpenOrCreate))
            {
                lock (fileStream)
                {
                    fileStream.SetLength(0);
                }
            }

            foreach (Book item in _bookList)
            {
                AddBook(item);
            }

            _bookList.Clear();
        }
    }
}
