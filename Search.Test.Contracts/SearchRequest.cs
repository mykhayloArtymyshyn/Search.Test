using Search.Test.Domain.Enums;

namespace Search.Test.Contracts
{
    public class SearchRequest
    {
        public Category Category { get; set; }
        public string Email { get; set; }
        public string Query { get; set; }
    }
}