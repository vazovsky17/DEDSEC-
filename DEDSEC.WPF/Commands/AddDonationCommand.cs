using DEDSEC.Domain.Models;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels;
using System;
using System.Collections.Generic;

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
            _donationStore.AddDonation(new Donation()
            {
                Id = Guid.NewGuid(),
                Donater = new Account()
                {
                    Id = Guid.NewGuid(),
                    AccountHolder = new User()
                    {
                        Id = Guid.NewGuid(),
                        Nickname = "VAZ",
                        Password = "883306"
                    },
                    Name = "MARINA",
                    Age = 23,
                    AboutMe = "Android developer",
                    IsVisited = true,
                    FavoriteGames = new List<Game>()
                },
                Value = _addDonationViewModel.Value
            });
                 
            _navigationService.Navigate();
        }
    }
}
