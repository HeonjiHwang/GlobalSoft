using GlobalSoft.Server.Data;
using GlobalSoft.Server.DataAccess;
using GlobalSoft.Server.Models;
using GlobalSoft.Shared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DomainModelPostgreSqlContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

/*
builder.Services.AddDefaultIdentity<UserInfoModel>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DomainModelPostgreSqlContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<UserInfoModel, DomainModelPostgreSqlContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();
*/
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IDataAccessProvider, DataAccessPostgreSqlProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

/*
app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();
*/

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
