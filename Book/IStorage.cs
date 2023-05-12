namespace Book
{
    internal interface IStorage
    {
        void AddBook(Book? book);

        Book? FindBookByISBN(string? isbn);

        void DeleteBook(string? isbn);

        void Update(Book? book);
    }
}
