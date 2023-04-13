using System.Xml.Linq;

namespace Book
{
    class Program
    {
        
            private class BaseBook
            {                
                
                public BaseBook Next { get; set; }
                public BaseBook Prev { get; set; }
            }

            

            private BaseBook _tail; //конец списка 
            private BaseBook _head; //начало списка

            public void Add(int pages)
            {
                BaseBook book = new BaseBook();
                Count++;
                if (_head == null)
                {
                    _head = book;
                    _tail = book;
                }
                else
                {
                    var current = _head;
                    if (current.Pages.Equals(pages))
                    {
                        while (current != _tail)
                        {
                            _tail.Next = book;
                            book.Prev = _tail;
                            _tail = book;
                        }
                    }

                }
            }

            public bool Remove(int pages)
            {
                var current = _head;
                while (current != _tail)
                {
                    if (current.Pages.Equals(pages))
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                        return true;
                    }
                    current = current.Next;
                }
                return false;
            }

            public int Count
            {
                get
                {
                    return Count;
                }
                private set
                {
                    Count = value;
                }
            }
        



        public static void Main(string[] args)
        {

        }
    }
}