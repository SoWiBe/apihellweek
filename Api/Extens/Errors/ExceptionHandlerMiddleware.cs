using Extens.Errors.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Extens.Errors;

public class ExceptionHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (BaseException e)
        {
            context.Response.Clear();
            context.Response.StatusCode = (int)e.StatusCode;
            await context.Response.WriteAsync(e.Message);
        }
        catch (Exception e)
        {
            context.Response.Clear();
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync(e.ToString());
        }
    }
}