using Book;
using System.ComponentModel.DataAnnotations;

namespace BookTests
{
    [TestFixture]
    public class Tests
    {
        readonly string path = "E:\\EduBlya\\filecsv.csv";

        [TearDown]
        public void DeleteFile_For_Clear_Data()
        {
            File.Delete(path);

        }

        [Test]
        public void Add_One_Book_To_TextFile_Test()
        {
            var bookStorageCSV = new BookListStorageFromCSV(path);
            var book = new Book.Book("978-5-699-12014-8", "Gandon", "Charlie Hebdo", 2001, 1488, 1.0M);
            string? fileContent;

            bookStorageCSV.AddBook(book);
            fileContent = File.ReadAllText(path);

            Assert.IsFalse(string.IsNullOrEmpty(fileContent)); //Assert.AreNotEqual(null, fileContent);
        }

        [TestCase("978-5-699-12014-8", true)]
        [TestCase("978-5-699-12014-7", false)]
        public void Find_One_Book_In_Textfile_By_ISBN(string ISBN, bool expectation)
        {
            var bookStorageCSV = new BookListStorageFromCSV(path);
            var book = new Book.Book("978-5-699-12014-8", "Gandon", "Charlie Hebdo", 2001, 1488, 1.0M);

            bookStorageCSV.AddBook(book);
            Book.Book? bookForSearch = bookStorageCSV.FindBookByISBN(ISBN);

            Assert.That(expectation, Is.EqualTo(book.Equals(bookForSearch)));
        }

        [TestCase("978-5-699-12014-8")]
        [TestCase("978-5-699-12014-7")]
        public void Delete_Single_Book_From_Text_file_Test(string ISBN)
        {
            var bookStorageCSV = new BookListStorageFromCSV(path);
            var book = new Book.Book(ISBN, "Gandon", "Charlie Hebdo", 2001, 1488, 1.0M);

            bookStorageCSV.AddBook(book);
            bookStorageCSV.DeleteBook(ISBN);

            Assert.IsFalse(File.Exists(path));
        }
        
        [TestCase("978-5-699-12014-8")]
        public void Delete_One_Book_From_TextFile_WithMoreTthatOneBook_Test(string ISBN)
        {
            var bookStorageCSV = new BookListStorageFromCSV(path);
            var book = new Book.Book("978-5-699-12014-8", "Gandon", "Charlie Hebdo", 2001, 1488, 1.0M);
            var book1 = new Book.Book("978-5-699-12014-7", "Gandon", "Charlie Hebdo", 2001, 1488, 1.0M);

            bookStorageCSV.AddBook(book);
            bookStorageCSV.AddBook(book1);
            bookStorageCSV.DeleteBook(ISBN);

            Assert.IsTrue(File.Exists(path));
            Assert.That(bookStorageCSV.FindBookByISBN(ISBN), Is.EqualTo(null));
        }

        [Test]
        public void Update_TxtFile_WithOneBook()
        {
            var bookStorageCSV = new BookListStorageFromCSV(path);
            var book = new Book.Book("978-5-699-12014-8", "Huilo", "Jopa", 2002, 1337, 1.3M);
            var book1 = new Book.Book("978-5-699-12014-8", "Gandon", "Charlie Hebdo", 2001, 1488, 1.0M);

            bookStorageCSV.AddBook(book);
            bookStorageCSV.Update(book1);

            Assert.That(true, Is.Not.EqualTo(Equals(bookStorageCSV.FindBookByISBN("978-5-699-12014-8"), book)));
        }

        [Test]
        public void Update_TxtFile_WithMoreThanOneBook()
        {
            var bookStorageCSV = new BookListStorageFromCSV(path);
            var book = new Book.Book("978-5-699-12014-8", "Huilo", "Jopa", 2002, 1337, 1.3M);            
            var book1 = new Book.Book("978-5-699-12014-8", "Gandon", "Charlie Hebdo", 2001, 1488, 1.0M);
            var book2 = new Book.Book("978-5-699-12014-7", "Huilo", "Jopa", 2002, 1337, 1.3M);

            bookStorageCSV.AddBook(book);
            bookStorageCSV.Update(book2);
            bookStorageCSV.Update(book1);

            Assert.That(true, Is.Not.EqualTo(Equals(bookStorageCSV.FindBookByISBN("978-5-699-12014-8"), book)));
        } 
    }
}