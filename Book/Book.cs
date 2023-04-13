namespace Book
{
    internal class Book
    {
        public string ISBN
        {
            get
            {
                return ISBN;//тут pizda а не формат он зависит даже от года
            }
            set
            {
                ISBN = value;
            }
        }
        public string Author
        {
            get
            {
                return Author;
            }
            set
            {
                if (Author != null)
                {
                    for (int i = 0; i <= 9; i++)
                    {
                        if (Author.Contains(Convert.ToChar(i)))
                        {
                            throw new CustomException(Author);
                        }
                    }
                }
                else
                {
                    throw new CustomException();
                }
                Author = value;
            }
        }
        public string PublishingHouse
        {
            get
            {
                return PublishingHouse;
            }
            set
            {
                if (value != null)
                {
                    PublishingHouse = value;
                }
                else
                {
                    throw new CustomException();
                }
            }
        }
        public int PublishingYear
        {
            get
            {
                return PublishingYear;
            }
            set
            {
                if (value != null)
                {
                    if (value > 2023 | value < 0)
                    {
                        throw new CustomException(value, 0, 2023);
                    }
                    else
                    {
                        PublishingYear = value;
                    }
                }
                else
                {
                    throw new CustomException();
                }
            }
        }
        public int Pages
        {
            get
            {
                return Pages;
            }
            set
            {
                if (value != null)
                {
                    if (value <= 0)
                    {
                        throw new CustomException(value, 0);
                    }
                    else
                    {
                        Pages = value;
                    }
                }
                else
                {
                    throw new CustomException();
                }
            }
        }
        public decimal Cost
        {
            get
            {
                return Cost;
            }
            set
            {
                if (value != null)
                {
                    if (Cost < 0)
                    {
                        throw new CustomException(value, 0);
                    }
                    else
                    {
                        Cost = value;
                    }
                }
                else
                {
                    throw new CustomException();
                }
            }
        }
    }
}
