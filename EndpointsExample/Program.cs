var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.UseRouting();

app.Use(async (HttpContext httpContext,RequestDelegate requestDelegate) =>
{
     Endpoint? endpoint= httpContext.GetEndpoint();
    await httpContext.Response.WriteAsync(endpoint?.DisplayName);
    await requestDelegate(httpContext);
});
app.UseEndpoints(endpoints =>
{
    endpoints.Map("map1", async (HttpContext context) =>
    {
        await context.Response.WriteAsync(context.Request.Path);
    });
    endpoints.Map("map2", async (HttpContext context) =>
    {
        await context.Response.WriteAsync(context.Request.Path);
    });
});

app.MapGet("/",()=>"Hello");


app.Run();
