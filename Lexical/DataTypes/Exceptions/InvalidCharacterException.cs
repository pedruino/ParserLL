using Lexical.Helpers;
using System;
using System.Runtime.Serialization;

namespace Lexical.DataTypes.Exceptions
{
    [Serializable]
    internal class InvalidCharacterException : Exception
    {
        public InvalidCharacterException()
        {
        }

        public InvalidCharacterException(string message) : base(message)
        {
        }

        public InvalidCharacterException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidCharacterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message
        {
            get
            {
                return Constants.Messages.InvalidCharacterException;
            }
        }
    }
}