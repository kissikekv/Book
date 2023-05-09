using System.Reflection;

namespace Book
{
    class Program
    {
        public static void Main(string[] args)
        {
            Book book = new Book("978-5-699-12014-8", "Gandon", "Charlie Hebdo", 2001, 1488, 1.0M);
            Book book1 = new Book("978-5-699-12014-7", "DickHead", "Charlie Hebdo", 2001, 1337, 1.0M);
            Book book2 = new Book("978-5-699-12014-7", "Pedik", "Charlie Hebdo", 2001, 2012, 1.0M);

            Console.WriteLine("enter smth");

            string someString = Console.ReadLine();

            switch (someString)
            {
                case "1":
                    someString = "BookInMemoryListStorage.cs";
                    break;
                case "2":
                    someString = "BookListStorageFromCSV.cs";
                    break;
                case "3":
                    someString = "BookStorageFileRW.cs";
                    break;
                default:
                    Console.WriteLine();
                    break;
            }

            Assembly asm = Assembly.LoadFrom("Book.dll");
            Type? type = asm.GetType(someString);

            if (type.Equals(null))
            {
                MethodInfo? FindBookByISBN = type.GetMethod("FindBookByISBN", BindingFlags.Public | BindingFlags.Instance);
                object? result = FindBookByISBN?.Invoke(null, null);
                Console.WriteLine(result);
            }
            else 
            {
                throw new ArgumentNullException();
            }
        }
    }
}
