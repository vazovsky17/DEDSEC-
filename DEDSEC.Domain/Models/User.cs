namespace DEDSEC.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
    }
}
