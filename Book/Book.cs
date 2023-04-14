namespace Book
{
    internal class Book
    {
        private string _ISBN;
        private string _author;
        private string _publishingHouse;
        private int? _publishingYear;
        private int? _pages;
        private decimal? _cost;

        static bool isValidIsbn(string isbn)
        {
            int n = isbn.Length;
            if (n != 10)
            {
                return false;
            }

            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int digit = isbn[i] - '0';
                if (0 > digit || 9 < digit)
                {
                    return false;
                }
                sum += (digit * (10 - i));
            }

            char last = isbn[9];

            if (last != 'X' && (last < '0' || last > '9'))
            {
                return false;
            }

            sum += ((last == 'X') ? 10 : (last - '0'));

            return (sum % 11 == 0);
        }

        public string ISBN
        {
            get
            {
                return _ISBN;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value");
                }
                else
                {
                    if (!isValidIsbn(value))
                    {
                        throw new Exception("value");
                    }
                    else
                    {
                        _ISBN = value;
                    }
                }
            }
        }

        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value");
                }
                else
                {
                    _author = value;
                }
            }
        }

        public string PublishingHouse
        {
            get
            {
                return _publishingHouse;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value");
                }
                else
                {
                    _publishingHouse = value;
                }
            }
        }
        //посмотреть встроеные эксепшены

        //сначала эксепшн, потом всё ок

        //now,  utc now
        public int? PublishingYear
        {
            get
            {
                return _publishingYear;
            }
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException("value");
                }
                else
                {
                    if (value > DateTime.UtcNow.Year | value < 0)
                    {
                        throw new ArgumentOutOfRangeException("value");
                    }
                    else
                    {
                        _publishingYear = value;
                    }
                }
            }
        }

        public int? Pages
        {
            get
            {
                return _pages;
            }
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException("value");
                }
                else
                {
                    if (value <= 0)
                    {
                        throw new ArgumentOutOfRangeException("value");
                    }
                    else
                    {
                        _pages = value;
                    }
                }
            }
        }

        public decimal? Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException("value");
                }
                else
                {
                    if (value <= 0)
                    {
                        throw new ArgumentOutOfRangeException("value");
                    }
                    else
                    {
                        _cost = value;
                    }
                }
            }
        }
    }
}




