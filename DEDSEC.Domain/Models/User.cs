namespace DEDSEC.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }

        public User(Guid id, string nickname, string password)
        {
            Id = id;
            Nickname = nickname;
            Password = password;
        }
    }
}
