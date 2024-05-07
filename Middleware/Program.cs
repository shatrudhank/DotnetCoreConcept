using Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<CustomMiddleware>();
var app = builder.Build();




app.Use(async (HttpContext context,RequestDelegate request) =>
{
    await context.Response.WriteAsync($"Hello from App.Use() {Environment.NewLine}");
    await request(context);
});

app.UseMiddleware<CustomMiddleware>();

app.UseMyMiddleware();

app.UseMiddlewareWithTemplate();

app.Run(async (HttpContext context) =>
{
   await  context.Response.WriteAsync($"Hello World from app.Run() {Environment.NewLine}");
});

// App run shortcircuit pipeline and does not forward request , so Hello World again!!! won't be printed
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello World again!!!");
});



app.Run();
