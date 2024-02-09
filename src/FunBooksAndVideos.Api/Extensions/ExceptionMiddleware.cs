
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace FunBooksAndVideos.Api.Extensions
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }
        public async  Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ProblemDetails problem = new()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Title = "An error occurred",
                    Detail = ex.Message,
                    Instance = context.Request.Path,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                    Extensions =
                    {
                        ["traceId"] = context.TraceIdentifier
                    }                   
                };
                var result = JsonConvert.SerializeObject(problem);
                context.Response.ContentType = "application/problem+json";
                await context.Response.WriteAsync(result);

            }
        }
    }
}
