using System;

namespace Cray.Exceptions
{
    public class CrayException : Exception
    {
        public CrayException(string message) : base(message)
        {
        }

        public CrayException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
