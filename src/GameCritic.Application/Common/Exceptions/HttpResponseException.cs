using System.Net;
using System.Runtime.Serialization;

namespace GameCritic.Application.Common.Exceptions
{
    [Serializable]
    public class ResponseException : Exception
    {
        private HttpStatusCode _badRequest;
        private string _errorMessage;

        public ResponseException()
        {
        }

        public ResponseException(string? message) : base(message)
        {
        }

        public ResponseException(HttpStatusCode badRequest, string message)
        {
            this._badRequest = badRequest;
            this._errorMessage = message;
        }

        public ResponseException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}