using System;
using System.Runtime.Serialization;

namespace Catalog.Core.Exceptions
{
    [Serializable]
    public class NameExceedsLengthLimitException : Exception
    {
        public NameExceedsLengthLimitException()
        {
        }

        public NameExceedsLengthLimitException(string message) : base(message)
        {
        }

        public NameExceedsLengthLimitException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NameExceedsLengthLimitException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}