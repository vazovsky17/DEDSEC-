namespace DEDSEC.Domain.Models
{
    public class User : DomainObject
    {
        public string Nickname { get; set; }
        public string Password { get; set; }
    }
}
