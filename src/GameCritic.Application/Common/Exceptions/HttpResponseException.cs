using System.Net;
using System.Runtime.Serialization;

namespace GameCritic.Application.Common.Exceptions
{
    [Serializable]
    public class HttpResponseException : Exception
    {
        private HttpStatusCode _badRequest;
        private string _errorMessage;

        public HttpStatusCode StatusCode { get => _badRequest; set => _badRequest = value; }
        public string Message { get => _errorMessage;  set => _errorMessage = value;  }

        public HttpResponseException()
        {
        }

        public HttpResponseException(string? message) : base(message)
        {
        }

        public HttpResponseException(HttpStatusCode badRequest, string message)
        {
            this._badRequest = badRequest;
            this._errorMessage = message;
        }

        public HttpResponseException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected HttpResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}