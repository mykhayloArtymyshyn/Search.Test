using Search.Test.Domain.Enums;
using Search.Test.Infrastructure.Factories;
using Microsoft.Extensions.Configuration;
using Search.Test.Domain.Entities;
using Search.Test.Domain.Interfaces;

namespace Search.Test.Infrastructure
{
    public class SearchService : ISearchService
    {
        private readonly ISearchRepository _searchRepository;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public SearchService(HttpClient httpClient, IConfiguration configuration, ISearchRepository searchRepository)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _searchRepository = searchRepository;
        }

        public async Task<List<Result>> SearchAsync(string email, Category category, string query)
        {
            var user = await _searchRepository.GetUserByEmailAsync(email);

            if (user == null)
            {
                user = new User
                {
                    Email = email
                };

                await _searchRepository.AddUserAsync(user);
            }
            var result = new List<Result>();
            if (category.HasFlag(Category.Movie))
            {
                var movieService = new MovieSearchService(_httpClient, _configuration);
                var movieResults = await QueryAndCashCategoryAsync(movieService, user, query);
                result.AddRange(movieResults);
            }
            if (category.HasFlag(Category.Book))
            {
                var bookService = new BookSearchService(_httpClient, _configuration);
                var bookResults = await QueryAndCashCategoryAsync(bookService, user, query);
                result.AddRange(bookResults);
            }
            return result;
        }
        private async Task<List<Result>> QueryAndCashCategoryAsync(ISearchByCategoryService service, User user, string queryText)
        {

            var res = await _searchRepository.GetUserQueryResultAsync(user, queryText, service.Category);
            if (res.Any())
                return res;
            var query = new Query
            {
                Text = queryText,
                Category = service.Category,
                Created = DateTime.UtcNow,
                User = user
            };

            await _searchRepository.AddQueryAsync(query);
            var results = await service.SearchAsync(queryText);
            results.ForEach(r => r.QueryId = query.Id);
            await _searchRepository.AddResultsAsync(results);
            return results;
        }
    }

}
