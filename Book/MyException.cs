namespace Book
{
    internal class CustomException : Exception
    {
        public int Value;
        public CustomException(int value, int minValue) : base($"Страниц в книге должно быть больше {minValue}")
        {}
        public CustomException(decimal value, int minValue) : base($"Цена книги должна быть больше {minValue}")
        {}
        public CustomException(int value, int minValue, int maxValue) : base($"Год должен быть больше {minValue} и меньше {minValue}")
        {}
        public CustomException(string someString) : base("Имя автора содержит недопустимые символы")
        {} 
    }
}
