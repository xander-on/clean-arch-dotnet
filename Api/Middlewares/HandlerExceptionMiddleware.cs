


using System.Net;
using System.Text.Json;
using Domain.Exceptions;

namespace Api.Middlewares;

public class HandlerExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public HandlerExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }


    private Task HandleException( HttpContext context, Exception exception)
    {
        HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
        var result = string.Empty;

        switch (exception)
        {
            case BusinessRuleException businessRuleException:
                httpStatusCode = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(businessRuleException.Message);
                break;
        }

        context.Response.StatusCode = (int)httpStatusCode;
        return context.Response.WriteAsync(result);
    }
}


public static class HandlerExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseHandlerException(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HandlerExceptionMiddleware>();
    }
}