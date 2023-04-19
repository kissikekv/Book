using System.Data;

namespace Book
{
    class Program
    {
        public static void Main(string[] args)
        {
            Book book = new Book();

            try
            {
                book.ISBN = "978-5-699-12014-7";
                book.Author = "Gandon";
                book.PublishingHouse = "Charlie Hebdo";
                book.Cost = 1.0M;
                book.PublishingYear = 2001;
                book.Pages = 1488;
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

            Console.WriteLine(book.ToString());
            /*почему перед ArgumentOutOfRangeException и ArgumentNullException не может стоять 
            ArgumentNullException????*/
            //ловить исключения try catch
            //override eq, getHash, ToString
        }
    }
}