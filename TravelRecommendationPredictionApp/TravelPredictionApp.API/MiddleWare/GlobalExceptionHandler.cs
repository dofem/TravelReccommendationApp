using Newtonsoft.Json;
using System.Net;

namespace TravelPredictionApp.API.MiddleWare
{
    public class GlobalExceptionHandler : IMiddleware
    {
        private ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex) 
            {
                string message = ex.Message.ToString();
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                _logger.LogError($"Exception Details:{message}");
                var response = new ExceptionDetails()
                { 
                    StatusCode = context.Response.StatusCode,
                    Message = message 
                };
                await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
        }
    }
}
