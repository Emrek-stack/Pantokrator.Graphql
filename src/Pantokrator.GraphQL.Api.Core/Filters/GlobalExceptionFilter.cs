using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Pantokrator.GraphQL.Api.Core.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);

            int statusCode = (int)HttpStatusCode.InternalServerError;
            context.HttpContext.Response.StatusCode = statusCode;
            context.Result = new JsonResult(new
            {
                StatusCode = statusCode,
                Message = "An exception occured."
            });
        }
    }
}