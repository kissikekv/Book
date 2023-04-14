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

        public string ISBN
        {
            get
            {
                return _ISBN;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value");
                }
                else
                {
                    if (!Validation.isValidIsbn(value))
                    {
                        throw new ArgumentException("value");
                    }
                }
                _ISBN = value;
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
                if (!string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value");
                }
                _author = value;
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
                if (!string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value");
                }
                _publishingHouse = value;
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
                }
                _publishingYear = value;
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
                }
                _pages = value;
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
                    _cost = value;
                }
            }
        }
    }
}