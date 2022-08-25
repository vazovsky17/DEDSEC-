using DEDSEC.Domain.Models;
using System;

namespace DEDSEC.WPF.Stores
{
    public class DonationGoalStore
    {
        public event Action<DonationGoal> DonationGoalAdded;

        public void AddDonationGoal(DonationGoal donationGoal)
        {
            DonationGoalAdded?.Invoke(donationGoal);
        }
    }
}
