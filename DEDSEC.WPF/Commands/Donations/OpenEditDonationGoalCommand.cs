using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Donations.DonationGoals;

namespace DEDSEC.WPF.Commands.Donations
{
    public class OpenEditDonationGoalCommand : CommandBase
    {
        private readonly DonationGoalViewModel _donationGoalViewModel;
        private readonly DonationGoalStore _donationGoalStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenEditDonationGoalCommand(DonationGoalViewModel donationGoalViewModel,
            DonationGoalStore donationGoalStore,
            ModalNavigationStore modalNavigationStore)
        {
            _donationGoalViewModel = donationGoalViewModel;
            _donationGoalStore = donationGoalStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            DonationGoal donationGoal = _donationGoalViewModel.DonationGoal;
            if (donationGoal != null)
            {
                EditDonationGoalViewModel editDonationGoalViewModel = new EditDonationGoalViewModel(
                    donationGoal, _donationGoalStore, _modalNavigationStore);
                _modalNavigationStore.CurrentViewModel = editDonationGoalViewModel;
            }
        }
    }
}
