using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Donations;
using System;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands.Donations
{
    public class EditDonationGoalCommand : AsyncCommandBase
    {
        private readonly EditDonationGoalViewModel _editDonationGoalViewModel;
        private readonly DonationGoalStore _donationGoalStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public EditDonationGoalCommand(EditDonationGoalViewModel editDonationGoalViewModel, DonationGoalStore donationGoalStore, ModalNavigationStore modalNavigationStore)
        {
            _editDonationGoalViewModel = editDonationGoalViewModel;
            _donationGoalStore = donationGoalStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var donationGoal = new DonationGoal()
            {
                Id = _editDonationGoalViewModel.DonationGoal.Id,
                Title = _editDonationGoalViewModel.DonationGoalFormViewModel.Title,
                Description = _editDonationGoalViewModel.DonationGoalFormViewModel.Description,
                CurrentValue = _editDonationGoalViewModel.DonationGoalFormViewModel.CurrentValue,
                TargetValue = _editDonationGoalViewModel.DonationGoalFormViewModel.TargetValue,
                Donations = _editDonationGoalViewModel.DonationGoal.Donations
            };
            if (donationGoal != null)
            {
                await _donationGoalStore.Update(donationGoal).ContinueWith(task =>
                {
                    if (task.IsCompleted)
                    {
                        _modalNavigationStore.Close();
                    }
                });
            }
        }
    }
}
