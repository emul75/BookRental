using System;
using System.Threading.Tasks;
using BookRental.Exceptions;
using Microsoft.AspNetCore.Http;

namespace BookRental.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (BookUnavailableException e)
            {
                context.Response.StatusCode = 405;
                await context.Response.WriteAsync(e.Message);
            }
            catch (InvalidDateFormatException e)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(e.Message);
            }
            catch (NotFoundException e)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(e.Message);
            }
            catch (NumberIsInUseException e)
            {
                context.Response.StatusCode = 405;
                await context.Response.WriteAsync(e.Message);
            }
            catch (Exception)
            {
                context.Response.StatusCode = 501;
                await context.Response.WriteAsync("Unspecified server error");
            }
        }
    }
}