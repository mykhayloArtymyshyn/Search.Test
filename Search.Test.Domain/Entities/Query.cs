using Search.Test.Domain.Enums;

namespace Search.Test.Domain.Entities
{
    public class Query : BaseEntity
    {
        public Category Category { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
