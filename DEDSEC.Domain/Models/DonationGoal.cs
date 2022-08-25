namespace DEDSEC.Domain.Models
{
    public class DonationGoal
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CurrentValue { get; set; }
        public int TargetValue { get; set; }
        public List<Donation> Donations { get; set; }
    }
}
