using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PZ;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

// Add authentication
// Using JSON Web Tokens
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            // TODO: URL and port config
            ValidIssuer = "https://localhost:5100",
            ValidAudience = "https://localhost:5100",
            // TODO: secret key config
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretkeymustbelong"))
        };
});
builder.Services.AddControllersWithViews();
builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder => 
    { 
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); 
    });
});
//string connStr = laodConnectionString(Configuration.GetConnectionString("DefaultConnection"),dbConnCrypt);
string connStr = "Host=localhost;Port=5432;Database=PZ;UserID=pzaccess;Password=ZAQ!2wsx";
// Add database connection
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connStr));
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors("EnableCORS");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();
