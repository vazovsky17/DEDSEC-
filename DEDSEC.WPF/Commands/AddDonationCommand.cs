using DEDSEC.Domain.Models;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels;
using System.Collections.Generic;
using System;

namespace DEDSEC.WPF.Commands
{
    public class AddDonationCommand : CommandBase
    {
        private readonly AddDonationViewModel _addDonationViewModel;
        private readonly DonationStore _donationStore;
        private readonly INavigationService _navigationService;

        public AddDonationCommand(AddDonationViewModel addDonationViewModel, DonationStore donationStore, INavigationService navigationService)
        {
            _addDonationViewModel = addDonationViewModel;
            _donationStore = donationStore;
            _navigationService = navigationService;
}

        public override void Execute(object parameter)
        {
            _donationStore.AddDonation(new Donation(
                 Guid.NewGuid(),
                 new Account(
                     Guid.NewGuid(),
                     new User(
                         Guid.NewGuid(),
                         "VAZ",
                         "883306"
                     ),
                     "Mark",
                     23,
                     "about meeeee",
                     true,
                     new List<Game>()
                     ),
                 _addDonationViewModel.Value));
            _navigationService.Navigate();
        }
    }
}
