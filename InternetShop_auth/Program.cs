using BusinessLogicLayer.Services.AccountServices;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository.AccountRepository;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

//configurations
var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddTransient<IAccountService, AccountServiceImpl>();

#region DBContext
builder.Services.AddDbContext<DatabaseContext>(
        optionsAction => optionsAction.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer"),
        migration => migration.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName))
    );
#endregion

#region Injections
builder.Services.AddTransient<IDatabaseContext, DatabaseContext>();

builder.Services.AddTransient<IAccountRepository, AccountRepository>();


builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

#endregion

#region Config

builder.Services.AddControllers();

#endregion

#region Auth

builder.Services.AddAuthentication("Bearer")
    .AddIdentityServerAuthentication("Bearer", 
        opt =>
        {
            opt.Authority = "https://localhost:5443";
            opt.ApiName = "AccountAPI";
        }
    );

#endregion

#region Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1"
    });
});
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

#endregion

app.Run();
