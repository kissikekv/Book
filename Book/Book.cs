namespace Book
{
    internal class Book : IEquatable<Book>, IComparable, IComparable<Book>
    {
        private string _ISBN;
        private string _author;
        private string _publishingHouse;
        private int _publishingYear;
        private int _pages;
        private decimal _cost;

        public Book(
            string isbn,
            string author,
            string publishinghouse,
            int publishingyear,
            int pages,
            decimal cost)
        {
            ISBN = isbn;
            Author = author;
            PublishingHouse = publishinghouse;
            PublishingYear = publishingyear;
            Pages = pages;
            Cost = cost;
        }

        public string ISBN
        {
            get
            {
                return _ISBN;
            }

            set
            {
                IsbnValidator.Validate(value);
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
                if (value > DateTime.UtcNow.Year || value < 0)
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
                if (value <= 0.0m)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), message: "Cost should be greater than zero");
                }

                _cost = value;
            }
        }

        public override string ToString()
        {
            return "ISBN: " + ISBN.ToString() +
                " Author: " + Author.ToString() +
                " Publishing House: " + PublishingHouse.ToString() +
                " Publishing Year: " + PublishingYear.ToString() +
                " Pages: " + Pages.ToString() +
                " Cost: " + Cost.ToString();
        }

        public override bool Equals(object? obj)
        {
            return object.ReferenceEquals(obj, this) &&
                   object.ReferenceEquals(obj, null) &&
                   obj is Book book &&
                   Equals(book);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(ISBN);
            hash.Add(Author);
            hash.Add(PublishingHouse);
            hash.Add(PublishingYear);
            hash.Add(Pages);
            hash.Add(Cost);
            return hash.ToHashCode();
        }

        public bool Equals(Book? other)
        {
            if (object.ReferenceEquals(other, this)) return true;
            if (object.ReferenceEquals(other, null)) return false;
            return ISBN == other.ISBN &&
            Author == other.Author &&
            PublishingHouse == other.PublishingHouse &&
            PublishingYear == other.PublishingYear &&
            Pages == other.Pages &&
            Cost == other.Cost;
        }

        public int CompareTo(Book? other)
        {
            if (object.ReferenceEquals(other, this))
            {
                return 0;
            }

            if (object.ReferenceEquals(other, null))
            {
                return -1;
            }

            return ISBN.CompareTo(other.ISBN);
        }

        public int CompareTo(object? obj)
        {
            if (object.ReferenceEquals(obj, this))
            {
                return 0;
            }

            if (object.ReferenceEquals(obj, null))
            {
                return -1;
            }

            if (obj is Book book)
            {
                return this.ISBN.CompareTo(book);
            }

            throw new ArgumentException(nameof(book));
        }                    

        public static bool operator <(Book left, Book right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Book left, Book right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Book left, Book right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Book left, Book right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static bool operator ==(Book left, Book right)
        {
            return left.Equals(right);
        }
        public static bool operator != (Book left, Book right)
        {
           return !(left == right);
        }


    }
}
