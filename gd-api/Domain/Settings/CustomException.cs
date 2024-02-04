using System.Net;

namespace gd_api.Domain.Settings
{
    public class CustomException : Exception
    {
        public CustomExceptionError Type { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public CustomException() : base() { }

        public CustomException(string message, CustomExceptionError type) : base(message)
        {
            Type = type;
            switch (type)
            {
                case CustomExceptionError.NotFound:
                    StatusCode = HttpStatusCode.NotFound; break;
                case CustomExceptionError.FormError:
                    StatusCode = HttpStatusCode.BadRequest; break;
                case CustomExceptionError.Unauthorized:
                    StatusCode = HttpStatusCode.Unauthorized; break;
                default:
                    StatusCode = HttpStatusCode.InternalServerError; break;
            }
        }
    }


}
