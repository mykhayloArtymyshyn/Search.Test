using Search.Test.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Search.Test.Domain.Entities;
using Search.Test.Domain.Interfaces;

namespace Search.Test.Infrastructure
{
    public class SearchRepository : ISearchRepository
    {
        private readonly SearchContext _context;

        public SearchRepository(SearchContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<List<Result>> GetUserQueryResultAsync(User user, string queryText, Category category)
        {
            var query = await _context.Queries.FirstOrDefaultAsync(u => u.UserId == user.Id && u.Text == queryText && u.Category == category);
            if (query != null)
            {
                var result = await _context.Results.Where(r => r.QueryId == query.Id).ToListAsync();
                if (result != null)
                    return result;
            }
            return new List<Result>();
        }

        public async Task AddQueryAsync(Query query)
        {
            _context.Queries.Add(query);
            await _context.SaveChangesAsync();
        }

        public async Task AddResultsAsync(List<Result> results)
        {
            _context.Results.AddRange(results);
            await _context.SaveChangesAsync();
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.AddRange(user);
            await _context.SaveChangesAsync();
        }
    }

}
