using System;
using System.Net;

namespace MediatrTutorial.Infrastructure.Exceptions
{
    public class RestException : Exception
    {
        public RestException(HttpStatusCode code, object message = null)
        {
            Code = code;
            Message = message;
        }

        public HttpStatusCode Code { get; }

        public new object Message { get; }
    }
}