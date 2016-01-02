using System;
using System.Runtime.Serialization;

namespace Common.Exceptions
{
    [Serializable]
    public class DuplicateEmailException : Exception
    {
        public DuplicateEmailException() : base("Email is already used")
        {
        }

        public DuplicateEmailException(string message) : base(message)
        {
        }

        public DuplicateEmailException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateEmailException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
