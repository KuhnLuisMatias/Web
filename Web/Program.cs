using Data;
var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "";
// Add services to the container.
builder.Services.AddCors(options =>
options.AddPolicy(name: MyAllowSpecificOrigins,
policy =>
{
    policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


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

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
