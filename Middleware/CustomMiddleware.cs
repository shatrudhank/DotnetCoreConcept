
namespace Middleware
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync($"Hello from custom middle ware before {Environment.NewLine}");
            await next(context);
            await context.Response.WriteAsync($"Hello from custom middle ware after {Environment.NewLine}");
        }
    }
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddleware>();
        }
    }
}
