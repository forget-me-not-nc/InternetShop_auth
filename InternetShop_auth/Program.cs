using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.AccountRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//config
builder.Services.AddControllers();

builder.Services.AddTransient<IAccountRepository, AccountRepository>();


builder.Services.AddDbContext<DatabaseContext>(
    options => options.UseSqlServer(builder.Configuration["ConnectionString"]));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddSignInManager<SignInManager<User>>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<DatabaseContext>();

//build
var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.MapGet("/", () => "Hello World!");

app.Run();
