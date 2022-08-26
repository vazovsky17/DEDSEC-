namespace DEDSEC.Domain.Models
{
    public class DonationGoal : DomainObject
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CurrentValue { get; set; }
        public int TargetValue { get; set; }
        public List<Donation> Donations { get; set; }
    }
}
