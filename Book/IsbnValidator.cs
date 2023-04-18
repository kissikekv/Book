using System.Text.RegularExpressions;

namespace Book
{
    internal static class IsbnValidator
    {
        public static bool IsValid(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentException(message: "Field is whitespace");
            }

            if (string.IsNullOrEmpty(isbn))
            {
                throw new ArgumentException(message: "Field is empty");
            }          

            const string isbn13Pattern = "^(?:ISBN(?:-13)?:? )?(?=[0-9]{13}$|" +
                                             "(?=(?:[0-9]+[- ]){4})[- 0-9]{17}$)97[89]" +
                                             "[- ]?[0-9]{1,5}[- ]?[0-9]+[- ]?[0-9]+[- ]?[0-9]$";

            var regularExpression = new Regex(isbn13Pattern);

            if (!regularExpression.IsMatch(isbn))
            {
                throw new ArgumentException("Invalid isbn format", nameof(isbn));
            }            

            return true;
        }
    }
}
