using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Book.Exceptions
{
    public class BookAlreadyExistException : Exception
    {
        public BookAlreadyExistException()
        {
        }

        public BookAlreadyExistException(string? message) : base(message)
        {
        }

        public BookAlreadyExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BookAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
