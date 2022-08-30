﻿using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Donations;
using System;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands
{
    /// <summary>
    /// Добавление доната
    /// </summary>
    public class AddDonationCommand : AsyncCommandBase
    {
        private readonly AddDonationViewModel _addDonationViewModel;
        private readonly AccountStore _accountStore;
        private readonly DonationGoalStore _donationGoalStore;
        private readonly INavigationService _navigationService;

        public AddDonationCommand(AddDonationViewModel addDonationViewModel, AccountStore accountStore, DonationGoalStore donationGoalStore, INavigationService navigationService)
        {
            _addDonationViewModel = addDonationViewModel;
            _accountStore = accountStore;
            _donationGoalStore = donationGoalStore;
            _navigationService = navigationService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var donation = new Donation()
            {
                Id = Guid.NewGuid(),
                Donater = _accountStore.CurrentAccount,
                Value = _addDonationViewModel.Value
            };

            await _donationGoalStore.AddDonation(donation).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    _navigationService.Navigate();
                }
            });
        }
    }
}
