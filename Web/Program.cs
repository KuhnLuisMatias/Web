using Data;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "";
// Add services to the container.
builder.Services.AddCors(options =>
options.AddPolicy(name: MyAllowSpecificOrigins,
policy =>
{
    policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, config =>
{
    config.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        context.Response.Redirect("https://localhost:7196");
        return Task.CompletedTask;
    };
});

/*
builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("ADMINISTRADORES", policy =>
    {
        policy.RequireRole("Administrador");
    });

    option.AddPolicy("USUARIOS", policy =>
    {
        policy.RequireRole("Usuario");
    });
});

*/

// Add services to the container.
builder.Services.AddControllersWithViews();

ApplicationDbContext.ConnectionString = builder.Configuration.GetConnectionString("ConnectionSRV");

builder.Services.AddHttpClient("useApi", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["ServiceUrl:ApiUrl"]);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
