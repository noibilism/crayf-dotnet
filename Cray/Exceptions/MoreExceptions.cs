using System;

namespace Cray.Exceptions
{
    public class AuthenticationException : CrayException
    {
        public AuthenticationException(string message) : base(message) { }
    }

    public class ValidationException : CrayException
    {
        public ValidationException(string message) : base(message) { }
    }

    public class RequestException : CrayException
    {
        public int StatusCode { get; }
        public string ResponseBody { get; }

        public RequestException(string message, int statusCode, string responseBody) : base(message)
        {
            StatusCode = statusCode;
            ResponseBody = responseBody;
        }
    }
}
