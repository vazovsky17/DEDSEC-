namespace DEDSEC.Domain.Models
{
    public class Donation
    {
        public Guid Id { get; set; }
        public Account Donater { get; set; }
        public int Value { get; set; }

        public Donation(Guid id, Account donater, int value)
        {
            Id = id;
            Donater = donater;
            Value = value;
        }
    }
}
