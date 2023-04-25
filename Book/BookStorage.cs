using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Exceptions;

namespace Book
{
    internal class BookInMemoryListStogare
    {
        private readonly List<Book> _books = new List<Book>();

        public void AddBook(Book? book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException(nameof(book));
            }

            if (ReferenceEquals(FindBookByISBN(book.ISBN), default))
            {
                _books.Add(book);
                return;
            }

            throw new BookAlreadyExistException();
        }

        public Book? FindBookByISBN(string? isbn)
        {
            foreach (Book book in _books)
            {
                if (book.ISBN == isbn)
                {
                    return book;
                }
            }

            return default;
        }

        public void DeleteBook(string? isbn)
        {
            var book = FindBookByISBN(isbn);

            if (ReferenceEquals(book, null))
            {
                return;
            }

            _books.Remove(book);
        }

        public void Update(Book? book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException(nameof(book));
            }

            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].ISBN == book.ISBN)
                {
                    _books[i] = book;
                    return;
                }
            }

            throw new BookNotFoundException();
        }
    }
}
