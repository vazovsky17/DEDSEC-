using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Donations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands
{
    /// <summary>
    /// Добавление донатной цели
    /// </summary>
    public class AddDonationGoalCommand : AsyncCommandBase
    {
        private readonly AddDonationGoalViewModel _addDonationGoalViewModel;
        private readonly DonationGoalStore _donationGoalStore;
        private readonly INavigationService _navigationService;

        public AddDonationGoalCommand(AddDonationGoalViewModel addDonationGoalViewModel, DonationGoalStore donationGoalStore, INavigationService navigationService)
        {
            _addDonationGoalViewModel = addDonationGoalViewModel;
            _donationGoalStore = donationGoalStore;
            _navigationService = navigationService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var donationGoal = new DonationGoal()
            {
                Id = Guid.NewGuid(),
                Title = _addDonationGoalViewModel.Title,
                Description = _addDonationGoalViewModel.Description,
                CurrentValue = _addDonationGoalViewModel.CurrentValue,
                TargetValue = _addDonationGoalViewModel.TargetValue,
                Donations = new List<Donation>()
            };

            await _donationGoalStore.Add(donationGoal).ContinueWith(task =>
            {
                _navigationService.Navigate();
            });
        }
    }
}
