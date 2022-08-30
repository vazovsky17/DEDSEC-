using DEDSEC.Domain.Models;
using System;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Donations
{
    public class DonationViewModel : ViewModelBase
    {
        public Donation Donation { get; private set; }
        public Guid Id => Donation.Id;
        public Account Donater => Donation.Donater;
        public int Value => Donation.Value;

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public DonationViewModel(Donation donation)
        {
            Donation = donation;
        }

        public void Update(Donation donation)
        {
            Donation = donation;
            OnPropertyChanged(nameof(Donation));
        }
    }
}
