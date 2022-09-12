﻿using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Commands.Donations;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Forms;

namespace DEDSEC.WPF.ViewModels.Donations
{
    public class EditDonationGoalViewModel : ViewModelBase
    {
        public DonationGoal DonationGoal { get; }
        public DonationGoalFormViewModel DonationGoalFormViewModel { get; }

        public EditDonationGoalViewModel(DonationGoal donationGoal,
            DonationGoalStore donationGoalStore,
            ModalNavigationStore modalNavigationStore)
        {
            DonationGoal = donationGoal;
            var SubmitCommand = new EditDonationGoalCommand(this, donationGoalStore, modalNavigationStore);
            var CancelCommand = new CloseModalCommand(modalNavigationStore);

            DonationGoalFormViewModel = new DonationGoalFormViewModel(SubmitCommand, CancelCommand)
            {
                Title = DonationGoal.Title,
                Description = DonationGoal.Description,
                CurrentValue = DonationGoal.CurrentValue,
                TargetValue = DonationGoal.TargetValue
            };
        }
    }
}
