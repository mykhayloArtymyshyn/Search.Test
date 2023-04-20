using Search.Test.Domain.Entities;
using Search.Test.Domain.Enums;

namespace Search.Test.Domain.Interfaces
{
    public interface ISearchByCategoryService
    {
        public Category Category { get; }
        Task<List<Result>> SearchAsync(string query);
    }
}
