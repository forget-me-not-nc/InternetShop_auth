using IdentityServer.Config;
using IdentityServer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var seed = args.Contains("/seed");

if (seed) args = args.Except(new[] { "/seed" }).ToArray();

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("SQLServer");

if (seed) SeedData.EnsureSeedData(connString);

var assembly = typeof(Program).Assembly.GetName().Name;

builder.Services.AddDbContext<MyIdentityDbContext>(opt =>
        opt.UseSqlServer(connString,
            b => b.MigrationsAssembly(assembly))
        );

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<MyIdentityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<IdentityUser>()
    .AddConfigurationStore(opt =>
    {
        opt.ConfigureDbContext = db =>
            db.UseSqlServer(connString, 
                option => option.MigrationsAssembly(assembly)
                );
    })
    .AddOperationalStore(opt =>
    {
        opt.ConfigureDbContext = db =>
            db.UseSqlServer(connString, 
                option => option.MigrationsAssembly(assembly)
                );
    })
    .AddDeveloperSigningCredential();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();
