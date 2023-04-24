using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    internal class BookStogare
    {
        //интерфейс IBookStorage
        private List<Book> _list;
        public List<Book> List
        {
            get
            {
                return _list;
            }
            set
            {
                _list = value;
            }
        }

        private void Create()
        {
            List<Book> list = new List<Book>();
            List = list;
        }

        public void RemoveBook(Book book)
        {
            foreach (Book item in List)
            {
                if (item.Equals(book))
                {
                    List.Remove(item);
                    return;
                }
            }
        }

        public void FindBookByTeg(Book book)
        {
            foreach (Book item in List)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void AddBook(Book book)
        {
            List.Add(book);
        }
    }
}
