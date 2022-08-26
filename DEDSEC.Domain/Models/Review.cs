namespace DEDSEC.Domain.Models
{
    public class Review : DomainObject
    {
        public Account ReviewAuthor { get; set; }
        public Game Game { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
