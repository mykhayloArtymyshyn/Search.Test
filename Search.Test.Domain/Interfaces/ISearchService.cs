using Search.Test.Domain.Entities;
using Search.Test.Domain.Enums;

namespace Search.Test.Domain.Interfaces
{
    public interface ISearchService
    {
        Task<List<Result>> SearchAsync(string email, Category category, string query);
    }
}
