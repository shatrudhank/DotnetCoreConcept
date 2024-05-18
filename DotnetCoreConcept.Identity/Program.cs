using DotnetCoreConcept.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>((option) =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddUserStore<UserStore<ApplicationUser,ApplicationRole, ApplicationDbContext, int>>()
    .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, int>>()
    .AddDefaultTokenProviders();


var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
