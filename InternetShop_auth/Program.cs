using DataAccessLayer;
using DataAccessLayer.Repository;
using DataAccessLayer.Repository.AccountRepository;
using DataAccessLayer.Repository.UserRepository;
using DataAccessLayer.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

//configurations
var builder = WebApplication.CreateBuilder(args);

#region DBContext
builder.Services.AddDbContext<DatabaseContext>(
        optionsAction => optionsAction.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer"),
        migration => migration.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName))
    );
#endregion


#region Injections
builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();

builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

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

builder.Services.AddControllers();

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
