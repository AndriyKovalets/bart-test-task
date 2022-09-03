using System.Net;
using System.Runtime.Serialization;

namespace TestTask.Domain.Exceptions
{
    [Serializable]
    public class BadRequestHttpException : HttpException
    {
        public BadRequestHttpException() { }

        public BadRequestHttpException(string message)
            : base(HttpStatusCode.BadRequest, message) { }

        public BadRequestHttpException(string message, Exception inner)
            : base(message, inner) { }

        protected BadRequestHttpException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
