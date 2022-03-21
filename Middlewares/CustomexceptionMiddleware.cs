using BookStore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookStore.Middlewares
{
    public class CustomexceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _service;
        public CustomexceptionMiddleware(RequestDelegate next, ILoggerService service)
        {
            _next = next;
            _service = service;
        }
        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                string message = "[Request] HTTP " + context.Request.Method + "-" + context.Request.Path;
                _service.Write(message);
                await _next(context);
                watch.Stop();
                
                message = "[Request] HTTP " + context.Request.Method + "-" + context.Request.Path + "Responed" + context.Response.StatusCode + "in" + watch.Elapsed.TotalMilliseconds+ "ms";
                _service.Write(message);
            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleException(context, ex, watch);
            }
          
        }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            string message = "[Error]   HTTP  "+ context.Request.Method+"-"+ context.Response.StatusCode+ "Error Message "+ ex.Message+ "in"+ watch.Elapsed.TotalMilliseconds + "ms";
            _service.Write(message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var result = JsonConvert.SerializeObject(new { error=ex.Message}, Formatting.None);
            return context.Response.WriteAsync(result);
        }
    }
    public static class CustomExceptionMiddlewareExtension
        {
        public static IApplicationBuilder UseCustomExceptionMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomexceptionMiddleware>();
        }

        }


}
