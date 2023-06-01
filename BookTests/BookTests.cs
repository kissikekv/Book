using Book;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookTests
{
    [TestFixture]
    public class Tests
    {
        private string path = "E:\\EduBlya\\filecsv.csv";
        private Book.Book testBook = new Book.Book("978-5-699-12014-8", "Gandon", "Charlie Hebdo", 2001, 1488, 1.0M);

        [TearDown]
        public void Delete_Data()
        {
            File.Delete(path);
        }

        [Test]
        public void Add_OneBook_ReturnSameBook()
        {
            var bookStorageCSV = new BookListStorageFromCSV(path);            
            string? fileContent;

            bookStorageCSV.AddBook(testBook);
            fileContent = File.ReadAllText(path);

            Assert.IsFalse(string.IsNullOrEmpty(fileContent)); 
        }

        [TestCase("978-5-699-12014-8", true)]
        [TestCase("978-5-699-12014-7", false)]
        public void Find_OneBook_ReturnSameBook(string ISBN, bool expectation)
        {
            var bookStorageCSV = new BookListStorageFromCSV(path);            

            bookStorageCSV.AddBook(testBook);
            Book.Book? bookForSearch = bookStorageCSV.FindBookByISBN(ISBN);

            Assert.That(expectation, Is.EqualTo(testBook.Equals(bookForSearch)));
        }

        [TestCase("978-5-699-12014-8")]
        [TestCase("978-5-699-12014-7")]
        public void Delete_OneBook_DeleteStorage(string ISBN)
        {
            var bookStorageCSV = new BookListStorageFromCSV(path);            
            var book = new Book.Book(ISBN, "Gandon", "Charlie Hebdo", 2001, 1488, 1.0M);

            bookStorageCSV.AddBook(book);
            bookStorageCSV.DeleteBook(ISBN);

            Assert.IsFalse(File.Exists(path));
        }
        
        [TestCase("978-5-699-12014-8")]
        public void Delete_OneBook_BookShouldBeDeleted(string ISBN)
        {
            var bookStorageCSV = new BookListStorageFromCSV(path);           
            var book1 = new Book.Book("978-5-699-12014-7", "Gandon", "Charlie Hebdo", 2001, 1488, 1.0M);

            bookStorageCSV.AddBook(testBook);
            bookStorageCSV.AddBook(book1);
            bookStorageCSV.DeleteBook(ISBN);

            Assert.IsTrue(File.Exists(path));
            Assert.That(bookStorageCSV.FindBookByISBN(ISBN), Is.EqualTo(null));
        }

        [Test]
        public void Update_OneBook_ReturnUpdatedBook()
        {
            var bookStorageCSV = new BookListStorageFromCSV(path);            
            var book1 = new Book.Book("978-5-699-12014-8", "Gandon", "Charlie Hebdo", 2001, 1488, 1.0M);

            bookStorageCSV.AddBook(testBook);
            bookStorageCSV.Update(book1);

            Assert.That(true, Is.Not.EqualTo(Equals(bookStorageCSV.FindBookByISBN("978-5-699-12014-8"), testBook)));
        }

        [Test]
        public void Update_OneBook_ReturnStorageWithoutSameBook()
        {
            var bookStorageCSV = new BookListStorageFromCSV(path);                        
            var book1 = new Book.Book("978-5-699-12014-8", "Gandon", "Charlie Hebdo", 2001, 1488, 1.0M);
            var book2 = new Book.Book("978-5-699-12014-7", "Huilo", "Jopa", 2002, 1337, 1.3M);

            bookStorageCSV.AddBook(testBook);
            bookStorageCSV.AddBook(book2);
            bookStorageCSV.Update(book1);

            Assert.That(true, Is.Not.EqualTo(Equals(bookStorageCSV.FindBookByISBN("978-5-699-12014-8"), testBook)));
        } 
    }
}