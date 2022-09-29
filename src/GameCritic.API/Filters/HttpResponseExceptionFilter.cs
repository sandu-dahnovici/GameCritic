using GameCritic.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GameCritic.API.Filters;

/// <summary>
///     Handles an <b>HttpResponseException</b> and creates relevant http response with the status code and error message
///     specified in the exception.
/// </summary>
public class HttpResponseExceptionFilter : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context.ExceptionHandled) return;

        if (context.Exception is HttpResponseException httpResponseException)
        {
            var responseBody = new
            {
                errors = new[] { httpResponseException.Message }
            };

            context.Result = new ObjectResult(responseBody)
            {
                StatusCode = (int)httpResponseException.StatusCode
            };

            context.ExceptionHandled = true;
        }
    }
}