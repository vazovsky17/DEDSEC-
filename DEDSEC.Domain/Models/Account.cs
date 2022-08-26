namespace DEDSEC.Domain.Models
{
    public class Account : DomainObject
    {
        public User AccountHolder { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string AboutMe { get; set; }
        public bool IsVisited { get; set; }
        public List<Game> FavoriteGames { get; set; }
    }
}
