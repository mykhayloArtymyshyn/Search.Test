using Search.Test.Domain.Enums;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Search.Test.Domain.Entities;
using Search.Test.Domain.Interfaces;

namespace Search.Test.Infrastructure.Factories
{
    public class MovieSearchService : ISearchByCategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public Category Category { get; set; } = Category.Movie;
        public MovieSearchService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<List<Result>> SearchAsync(string query)
        {
            var apiKey = _configuration.GetSection("OMDbApiKey").Value;
            var url = $"http://www.omdbapi.com/?apikey={apiKey}&s={query}&type=movie";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var results = (JArray)JObject.Parse(content).GetValue("Search");

            return results.Select(s =>
            {
                var obj = (JObject)s;
                return new Result
                {
                    Title = obj.GetValue("Title").ToString(),
                    Poster = obj.GetValue("Poster").ToString(),
                    Type = Category.Movie.ToString(),
                    Year = int.Parse(obj.GetValue("Year").ToString())
                };
            }).ToList();
        }
    }

}
