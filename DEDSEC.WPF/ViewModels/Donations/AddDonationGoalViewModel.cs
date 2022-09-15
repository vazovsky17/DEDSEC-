﻿using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Commands.Donations;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Forms;

namespace DEDSEC.WPF.ViewModels.Donations
{
    public class AddDonationGoalViewModel : ViewModelBase
    {
        public DonationGoalFormViewModel DonationGoalFormViewModel { get; }

        public AddDonationGoalViewModel(DonationGoalStore donationGoalStore,
            INavigationService closeNavigationService)
        {
            var SubmitCommand = new AddDonationGoalCommand(this, donationGoalStore, closeNavigationService);
            var CancelCommand = new NavigateCommand(closeNavigationService);
            DonationGoalFormViewModel = new DonationGoalFormViewModel(SubmitCommand, CancelCommand);
        }
    }
}
