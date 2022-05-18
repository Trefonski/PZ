using Microsoft.EntityFrameworkCore;
using PZ;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
string connStr = "Host=localhost;Port=5432;Database=PZ;UserID=pzaccess;Password=ZAQ!2wsx";
//string connStr = laodConnectionString(Configuration.GetConnectionString("DefaultConnection"),dbConnCrypt);
// Add database connection
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connStr));
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();
