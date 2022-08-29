using DEDSEC.Domain.Models;
using System;

namespace DEDSEC.WPF.ViewModels.Donations
{
    public class DonationViewModel : ViewModelBase
    {
        public Donation Donation { get; }
        public Guid Id => Donation.Id;
        public Account Donater => Donation.Donater;
        public int Value => Donation.Value;

        public DonationViewModel(Donation donation)
        {
            Donation = donation;
        }
    }
}
