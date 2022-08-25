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
    }
}
