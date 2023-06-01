using System.Threading.Channels;

namespace Book
{
    class Program
    {
        public static void Main(string[] args)
        {
            Book book = new Book("978-5-699-12014-8", "Gandon", "Charlie Hebdo", 2001, 1488, 1.0M);
            Book book1 = new Book("978-5-699-12014-7", "DickHead", "Charlie Hebdo", 2001, 1337, 1.0M);
            Book book2 = new Book("978-5-699-12014-7", "Pedik", "Charlie Hebdo", 2001, 2012, 1.0M);
            
            string tempISBN = book1.ISBN;

            Console.WriteLine("enter smth");

            string? someString = Console.ReadLine();
                     
            var storage = CreateStorage(someString);  

            storage.AddBook(book);
            storage.AddBook(book1);
            storage.AddBook(book2);            
        }
                
        public static IStorage CreateStorage(string? someString)
        {
            switch (someString)
            {
                case "1":                    
                    return new BookInMemoryListStogare();                    
                case "2":
                    return new BookListStorageFromCSV("jopa.csv");                    
                case "3":
                    return new BookStorageFileRW("binarystorage.dat");                    
                default:
                    throw new ArgumentOutOfRangeException(nameof(someString));                    
            }            
        }
    }
}
