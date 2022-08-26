namespace DEDSEC.Domain.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinCountPlayers { get; set; }
        public int MaxCountPlayers { get; set; }
        public string LinkHobbyGames { get; set; }
        public List<Review> Reviews { get; set; }

        public Game(Guid id, string name, string description, int minCountPlayers, int maxCountPlayers, string linkHobbyGames, List<Review> reviews)
        {
            Id = id;
            Name = name;
            Description = description;
            MinCountPlayers = minCountPlayers;
            MaxCountPlayers = maxCountPlayers;
            LinkHobbyGames = linkHobbyGames;
            Reviews = reviews;
        }
    }
}
