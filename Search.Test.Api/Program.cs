using Microsoft.EntityFrameworkCore;
using Search.Test.Domain.Interfaces;
using Search.Test.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddMvcCore();

//services
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<SearchService>(c => c.BaseAddress = new System.Uri("http://www.omdbapi.com"));
builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddDbContext<SearchContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("DbContext")));//.AddDbContext<SearchContext>();
builder.Services.AddScoped<ISearchRepository, SearchRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

//app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(e => e.MapControllerRoute("default", "{controller}/{action}", new { controller = "Search", action = "Index" }));

app.MapControllers();

app.Run();

