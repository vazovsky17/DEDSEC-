namespace DEDSEC.Domain.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public User AccountHolder { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string AboutMe { get; set; }
        public bool IsVisited { get; set; }
        public List<Game> FavoriteGames { get; set; }

        public Account(Guid id, User accountHolder, string name, int age, string aboutMe, bool isVisited, List<Game> favoriteGames)
        {
            Id = id;
            AccountHolder = accountHolder;
            Name = name;
            Age = age;
            AboutMe = aboutMe;
            IsVisited = isVisited;
            FavoriteGames = favoriteGames;
        }
    }
}
