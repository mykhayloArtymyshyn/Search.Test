using Microsoft.EntityFrameworkCore;
using Search.Test.Domain.Interfaces;
using Search.Test.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<SearchService>(c => c.BaseAddress = new System.Uri("http://www.omdbapi.com"));
builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddDbContext<SearchContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("DbContext")));//.AddDbContext<SearchContext>();
builder.Services.AddScoped<ISearchRepository, SearchRepository>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
