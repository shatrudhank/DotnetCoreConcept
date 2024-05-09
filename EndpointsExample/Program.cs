var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.Use(async (HttpContext httpContext, RequestDelegate next) =>
{
    Endpoint? endpoint = httpContext.GetEndpoint();
    string requesturl = endpoint?.DisplayName ?? "np";
    // await httpContext.Response.WriteAsync($"{requesturl}{Environment.NewLine}");
    await next(httpContext);
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

    endpoints.Map("files/{filename}.{extension}", async (HttpContext context) =>
    {
        string fileName =context.Request.RouteValues["filename"].ToString();
        string extension = context.Request.RouteValues["extension"].ToString();
        await context.Response.WriteAsync($"Filename= {fileName}, Extension= {extension}");
    });

});

app.MapGet("/",()=>"Hello");


app.Run();
