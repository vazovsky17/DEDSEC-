﻿using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Donations;
using DEDSEC.WPF.Stores;
using System;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Donations.Donations
{
    public class DonationViewModel : ViewModelBase
    {
        public bool IsAdmin { get; }

        public Donation Donation { get; private set; }
        public Guid Id => Donation.Id;
        public Account Donater => Donation.Donater;
        public int Value => Donation.Value;

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public DonationViewModel(Donation donation, DonationsStore donationsStore, bool isAdmin)
        {
            IsAdmin = isAdmin;
            Donation = donation;

            DeleteCommand = new DeleteDonationCommand(donationsStore, donation);
        }

        public void Update(Donation donation)
        {
            Donation = donation;
            OnPropertyChanged(nameof(Donation));
        }
    }
}
