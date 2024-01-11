using System.Net;

namespace Adveture.WebApiProject
{
    public class MyLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger _logger;


        public MyLoggingMiddleware(RequestDelegate next, ILoggerFactory factory)
        {
            _next = next;
            _logger = factory.CreateLogger("Information");
        }

        public async Task Invoke(HttpContext context)
        {
            //context.Response.WriteAsync("slsldkfjlsdf");

            _logger.Log(LogLevel.Information, "MyLoggingMiddleware start ");
            context.Response.StatusCode = (int)HttpStatusCode.Created;

            await _next.Invoke(context);

            _logger.Log(LogLevel.Information, "MyLoggingMiddleware finish ");
        }
    }
}
