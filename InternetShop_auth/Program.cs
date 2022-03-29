using BusinessLogicLayer.Services.AccountServices;
using BusinessLogicLayer.Services.UserServices;
using DataAccessLayer;
using DataAccessLayer.Repository;
using DataAccessLayer.Repository.AccountRepository;
using DataAccessLayer.Repository.UserRepository;
using DataAccessLayer.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

//configurations
var builder = WebApplication.CreateBuilder(args);

#region DBContext
builder.Services.AddDbContext<DatabaseContext>(
        optionsAction => optionsAction.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer"),
        migration => migration.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName))
    );
#endregion


#region Injections
builder.Services.AddTransient<IDatabaseContext, DatabaseContext>();

builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<IAccountService, AccountServiceImpl>();
builder.Services.AddTransient<IUserService, UserServiceImpl>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

#region Config


#endregion

#region Swagger
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "IntenetShop_auth",
    });
});
#endregion

//build
var app = builder.Build();

#region Swagger

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "IntenetShop_auth v1");
});
#endregion

#region Routing
app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
#endregion

app.MapGet("/", () => "Hello World!");

app.Run();
