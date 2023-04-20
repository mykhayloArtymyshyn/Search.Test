namespace Search.Test.Domain.Entities
{
    public class Result : BaseEntity
    {
        public string Title { get; set; }
        public string Poster { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        // public string ImdbId { get; set; }
        public int QueryId { get; set; }
        public Query Query { get; set; }
    }
}
