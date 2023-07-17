using System.Net;
using System.Text.Json;

namespace eShield_API.MiddleWares
{
    public class ErrorHandlingMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context, IWebHostEnvironment env)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong{break}{exception}", Environment.NewLine, ex);
                await HandleExceptionAsync(context, ex, env);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, IWebHostEnvironment env)
        {
            var status = HttpStatusCode.InternalServerError;
            var message = "An unexpected error occurred";
            var stackTrace = env.IsDevelopment() ? exception.StackTrace : null;

            var result = JsonSerializer.Serialize( new { error = message, StackTrace = stackTrace } );
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsync(result);
        }
    }
}
