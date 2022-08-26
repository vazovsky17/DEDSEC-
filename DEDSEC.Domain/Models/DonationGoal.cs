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

        public DonationGoal(Guid id, string title, string description, int currentValue, int targetValue, List<Donation> donations)
        {
            Id = id;
            Title = title;
            Description = description;
            CurrentValue = currentValue;
            TargetValue = targetValue;
            Donations = donations;
        }
    }
}
