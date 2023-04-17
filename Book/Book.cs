namespace Book
{
    internal class Book
    {
        private string _ISBN;
        private string _author;
        private string _publishingHouse;
        private int _publishingYear;
        private int _pages;
        private decimal _cost;

        public string ISBN
        {
            get
            {
                return _ISBN;
            }

            set
            {
                if (IsbnValidator.IsValidIsbn(value))
                {
                    throw new FormatException(nameof(value));
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), message: "Field is empty");
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), message: "Field is empty");
                }

                _publishingHouse = value;
            }
        }

        public int PublishingYear
        {
            get
            {
                return _publishingYear;
            }

            set
            {
                if (value > DateTime.UtcNow.Year | value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), message: "Incorrect year value");
                }

                _publishingYear = value;
            }
        }

        public int Pages
        {
            get
            {
                return _pages;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), message: "Number of pages should be greater than zero");
                }

                _pages = value;
            }
        }

        public decimal Cost
        {
            get
            {
                return _cost;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), message: "Cost should be greater than zero");
                }

                _cost = value;
            }
        }        
    }
}
