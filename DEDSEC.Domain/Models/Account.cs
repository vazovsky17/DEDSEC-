namespace DEDSEC.Domain.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public User AccountHolder { get; set; }

        public Account(Guid id, User accountHolder)
        {
            Id = id;
            AccountHolder = accountHolder;
        }
    }
}
