using Book;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookTests
{
    [TestFixture]
    public class Tests
    {
        const string path = "E:\\EduBlya\\filecsv.csv";        
        const string firstTestIsbn = "978-5-699-12014-8";
        const string secondTestIsbn = "978-5-699-12014-7";
        private Book.Book testBook = new Book.Book(firstTestIsbn, "Gandon", "Charlie Hebdo", 2001, 1488, 1.0M);

        [TearDown]
        public void DeleteData()
        {
            File.Delete(path);
        }

        [Test]
        public void Add_OneBook_OneBookAdded()
        {
            var bookStorageCSV = new BookListStorageFromCSV(path); 

            bookStorageCSV.AddBook(testBook);
            string? fileContent = File.ReadAllText(path);

            Assert.IsFalse(string.IsNullOrEmpty(fileContent)); 
        }

        [TestCase(firstTestIsbn, true)]
        [TestCase(secondTestIsbn, false)]
        public void Find_OneBook_OneBookFinded(string ISBN, bool expectation)
        {
            var bookStorageCSV = new BookListStorageFromCSV(path);            

            bookStorageCSV.AddBook(testBook);
            Book.Book? bookForSearch = bookStorageCSV.FindBookByISBN(ISBN);

            Assert.That(expectation, Is.EqualTo(testBook.Equals(bookForSearch)));
        }

        [TestCase(firstTestIsbn)]
        [TestCase(secondTestIsbn)]
        public void Delete_OneBook_StorageDeleted(string ISBN)
        {
            var bookStorageCSV = new BookListStorageFromCSV(path);            
            var book = new Book.Book(ISBN, "Gandon", "Charlie Hebdo", 2001, 1488, 1.0M);

            bookStorageCSV.AddBook(book);
            bookStorageCSV.DeleteBook(ISBN);

            Assert.IsFalse(File.Exists(path));
        }
        
        [Test]
        public void Delete_OneBook_BookIsDeleted()
        {
            var bookStorageCSV = new BookListStorageFromCSV(path);           
            var book1 = new Book.Book(secondTestIsbn, "Gandon", "Charlie Hebdo", 2001, 1488, 1.0M);

            bookStorageCSV.AddBook(testBook);
            bookStorageCSV.AddBook(book1);
            bookStorageCSV.DeleteBook(firstTestIsbn);

            Assert.IsTrue(File.Exists(path));
            Assert.That(bookStorageCSV.FindBookByISBN(firstTestIsbn), Is.EqualTo(null));
        }

        [Test]
        public void Update_OneBook_BookIsUpdate()
        {
            var bookStorageCSV = new BookListStorageFromCSV(path);            
            var book1 = new Book.Book(firstTestIsbn, "Gandon", "Charlie Hebdo", 2001, 1488, 1.0M);

            bookStorageCSV.AddBook(testBook);
            bookStorageCSV.Update(book1);

            Assert.That(true, Is.Not.EqualTo(Equals(bookStorageCSV.FindBookByISBN(firstTestIsbn), testBook)));
        }

        [Test]
        public void Update_OneBook_ReturnStorageWithoutSameBook()
        {
            var bookStorageCSV = new BookListStorageFromCSV(path);                        
            var book1 = new Book.Book(firstTestIsbn, "Gandon", "Charlie Hebdo", 2001, 1488, 1.0M);
            var book2 = new Book.Book(secondTestIsbn, "Huilo", "Jopa", 2002, 1337, 1.3M);

            bookStorageCSV.AddBook(testBook);
            bookStorageCSV.AddBook(book2);
            bookStorageCSV.Update(book1);

            Assert.That(true, Is.Not.EqualTo(Equals(bookStorageCSV.FindBookByISBN(firstTestIsbn), testBook)));
        } 
    }
}