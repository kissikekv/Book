using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    internal class BookListStogare
    {
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

        public void Delete(Book book)
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

        public void Read(Book book)
        {
            foreach (Book item in List)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void Update(Book book)
        {
            List.Add(book);
        }
    }
}
