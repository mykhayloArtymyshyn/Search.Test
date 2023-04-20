using Search.Test.Domain.Entities;

namespace Search.Test.Contracts
{
    public class SearchResponse: SearchRequest
    {
        public List<Result> Results { get; set; }
        //  public List<string> Headers { get; set; }
        //  public Dictionary<string, string> Source { get; set; }
    }
}