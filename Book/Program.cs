using System.Data;

namespace Book
{
    class Program
    {
        public static void Main(string[] args)
        {
            Book book = new Book("978-5-699-12014-7", "Gandon", "Charlie Hebdo", 2001, 1488, 1.0M );

            try
            {
                
            }
            
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }          
            
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(book.Equals(null));
            Console.WriteLine(book.ToString());            
        }
    }
}