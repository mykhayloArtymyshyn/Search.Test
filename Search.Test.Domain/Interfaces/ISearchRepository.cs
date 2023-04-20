using Search.Test.Domain.Entities;
using Search.Test.Domain.Enums;

namespace Search.Test.Domain.Interfaces
{
    public interface ISearchRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<List<Result>> GetUserQueryResultAsync(User user, string queryText, Category category);
        Task AddQueryAsync(Query query);
        Task AddResultsAsync(List<Result> results);
        Task AddUserAsync(User user);
    }
}
