using BusinessLogicLayer.Services.AccountServices;
using BusinessLogicLayer.Services.UserServices;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using DataAccessLayer.Repository.AccountRepository;
using DataAccessLayer.Repository.UserRepository;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Identity;
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

#region Identity

builder.Services.AddIdentity<User, IdentityRole>(
        opts =>
        { 
            opts.Password.RequiredLength = 5;   
            opts.Password.RequireNonAlphanumeric = false;  
            opts.Password.RequireLowercase = false; 
            opts.Password.RequireUppercase = false; 
            opts.Password.RequireDigit = false;
        }
    )
    .AddEntityFrameworkStores<DatabaseContext>();

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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

#endregion

#region Swagger
builder.Services.AddSwaggerGen();
#endregion

//build
var app = builder.Build();

#region Swagger

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "IntenetShop_auth v1");
    });
}
#endregion

#region Routing
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
#endregion

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
