using DEDSEC.Domain.Models;
using System;

namespace DEDSEC.WPF.Stores
{
    public class DonationStore
    {
        public event Action<Donation> DonationAdded;

        public void AddDonation(Donation donation)
        {
            DonationAdded?.Invoke(donation);
        }
    }
}
