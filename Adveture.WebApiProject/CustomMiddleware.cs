namespace Adveture.WebApiProject
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public CustomMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            _next = next;
            _logger = logger.CreateLogger("loggerName");
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.Log(LogLevel.Information, "CustomMiddleware Start");

            await _next.Invoke(context);

            _logger.Log(LogLevel.Information, " CustomMiddleware Finish");
        }
    }


    public static class WebApplicationExtentions
    {
        public static IApplicationBuilder UseCustomMiddleware(this WebApplication app)
        { 
            return app.UseMiddleware<CustomMiddleware>();
        }
    }
}
