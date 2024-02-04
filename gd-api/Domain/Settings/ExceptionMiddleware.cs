using Newtonsoft.Json;
using System.Net;

namespace gd_api.Domain.Settings
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CustomException ex)
            {
                context.Response.StatusCode = (int)ex.StatusCode;
                var jsonResponse = BuildException(context, ex.Message, ex.Type);
                await context.Response.WriteAsync(jsonResponse);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                var jsonResponse = BuildException(context, "Ocorreu um erro inesperado");
                await context.Response.WriteAsync(jsonResponse);
            }
        }

        public string BuildException(HttpContext context, string message, CustomExceptionError type = CustomExceptionError.Undefined)
        {
            var responseObject = new { ErrorMessage = message, CustomKey = type };
            var jsonResponse = JsonConvert.SerializeObject(responseObject);

            if (context.Response.StatusCode >= 400)
            {
                context.Response.ContentType = "application/json; charset=utf-8";
            }
            else
            {
                context.Response.ContentType = "application/json";
            }

            return jsonResponse;
        }
    }
}
