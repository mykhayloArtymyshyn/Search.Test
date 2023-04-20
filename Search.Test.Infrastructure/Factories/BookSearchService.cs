using Search.Test.Domain.Enums;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Search.Test.Domain.Entities;
using Search.Test.Domain.Interfaces;

namespace Search.Test.Infrastructure.Factories
{
    public class BookSearchService : ISearchByCategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public Category Category { get; set; } = Category.Book;

        public BookSearchService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<List<Result>> SearchAsync(string query)
        {
            var url = $"https://www.googleapis.com/books/v1/volumes?q={query}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var results = (JArray)JObject.Parse(content).GetValue("items");

            return results.Select(s =>
            {
                var obj = (JObject)((JObject)s).GetValue("volumeInfo");
                var title = obj.GetValue("title").ToString();
                var poster = ((JObject)obj.GetValue("imageLinks")).GetValue("thumbnail").ToString();
                int year = 0;
                int.TryParse(obj.GetValue("publishedDate")?.ToString().Split("-")[0], out year);
                return new Result
                {
                    Title = title,
                    Poster =  poster,
                    Type = Category.Book.ToString(),
                    Year = year
                };
            }).ToList();
        }
    }

}
