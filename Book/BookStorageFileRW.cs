namespace Book
{
    internal class BookStorageFileRW : IStorage
    {
        private string _path;

        public BookStorageFileRW(string path)
        {
            Validator.ValidateFilePath(path);
            _path = path;       
        }

        public void AddBook(Book? book)
        {
            Validator.ValidateBookForNull(book);
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
            if (ReferenceEquals(bookForDelete, null))
            {
                return;
            }
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
