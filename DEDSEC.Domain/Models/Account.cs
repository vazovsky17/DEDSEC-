namespace DEDSEC.Domain.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public User AccountHolder { get; set; }
    }
}
