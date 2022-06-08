using Client.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.Configure<IdentityServerSettings>(
        builder.Configuration.GetSection("IdentityServerSettings")
    );

builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddAuthentication(
        opt =>
        {
            opt.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme; 
        }
    )
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme,
        opt =>
        {
            opt.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            opt.SignOutScheme = OpenIdConnectDefaults.AuthenticationScheme;
            opt.Authority = builder.Configuration["InteractiveServiceSettings:AuthorityUrl"];
            opt.ClientId = builder.Configuration["InteractiveServiceSettings:ClientId"];
            opt.ClientSecret = builder.Configuration["InteractiveServiceSettings:ClientSecret"];
            opt.ResponseType = "code";
            opt.SaveTokens = true;
            opt.GetClaimsFromUserInfoEndpoint = true;
            opt.Scope.Add("AccountAPI.read");
        }
    );

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
