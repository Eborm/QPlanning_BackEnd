using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using QPlanning.Business.Domain.Entities.Logging;
using QPlanning.Business.Interfaces.Services;

namespace QPlanning.Business.Extensions.Middleware
{
    public class ExceptionPersistenceMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;

        public ExceptionPersistenceMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }   
        
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var uaString = context.Request.Headers["User-Agent"].ToString();
                var uid = "Unknown";
                if (context.User.Identity.IsAuthenticated)
                {
                    uid = context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                }

                StringBuilder sb = new StringBuilder($"An error has occurred on {context.Request.Host}. \r\n \r\n");
                sb.Append($"Path = {context.Request.Path} \r\n \r\n");
                sb.Append($"Error Message = {ex.Message} \r\n");
                sb.Append($"Error Source = {ex.Source} \r\n");

                sb.Append(ex.InnerException != null
                    ? $"Inner Exception = {ex.InnerException.ToString()} \r\n"
                    : "Inner Exception = null \r\n");

                sb.Append($"Error StackTrace = {ex.StackTrace} \r\n");

                await _loggerService.PersistException(new DomainModelExceptionLog {
                    RequestHost = $"Error on {context.Request.Host}.", 
                    ExceptionLogMessage = sb.ToString(), 
                    HeaderInfo = uaString, 
                    ContextUser = uid});

                throw new InvalidOperationException($"Recorded By Middleware: {ex.Message}");
                
            }
        }
    }
}