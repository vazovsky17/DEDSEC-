namespace DEDSEC.Domain.Models
{
    public class Donation : DomainObject
    {
        public Account Donater { get; set; }
        public int Value { get; set; }
    }
}
