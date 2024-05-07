﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareWithTemplate
    {
        private readonly RequestDelegate _next;

        public MiddlewareWithTemplate(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.WriteAsync($"<b>From middleware template<b>{Environment.NewLine}");
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareWithTemplateExtensions
    {
        public static IApplicationBuilder UseMiddlewareWithTemplate(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareWithTemplate>();
        }
    }
}
