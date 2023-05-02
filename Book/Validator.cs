using System.Text.RegularExpressions;

namespace Book
{
    internal static class Validator
    {
        public static void ValidateISBN(string isbn)
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
        }

        public static void ValidateFilePath(string filePath)
        {
            try
            {
                UriBuilder uriBuilder = new UriBuilder();
                uriBuilder.Scheme = Uri.UriSchemeFile;
                uriBuilder.Path = filePath;

                bool isValid = Uri.TryCreate(uriBuilder.Uri.ToString(), UriKind.Absolute, out Uri resultUri);
            }
            catch (UriFormatException)
            {
                throw new FormatException(message: "Invalid path format");
            }
        }

        public static void ValidateBookForNull(Book? book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException(nameof(book));
            }
        }
    }
}
