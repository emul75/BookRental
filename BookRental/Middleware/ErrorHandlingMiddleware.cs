using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BookRental.Middleware
{
    public class ErrorHandlingMiddleware :IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Unspecified server error");
            }
        }
    }
}