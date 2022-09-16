using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Donations.Donations;

namespace DEDSEC.WPF.Commands.Donations
{
    public class OpenEditDonationCommand : CommandBase
    {
        private readonly DonationViewModel _donationViewModel;
        private readonly DonationGoalStore _donationGoalStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenEditDonationCommand(DonationViewModel donationViewModel,
            DonationGoalStore donationGoalStore,
            ModalNavigationStore modalNavigationStore)
        {
            _donationViewModel = donationViewModel;
            _donationGoalStore = donationGoalStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            Donation donation = _donationViewModel.Donation;

            EditDonationViewModel editDonationViewModel = new EditDonationViewModel(
                donation, _donationGoalStore, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = editDonationViewModel;
        }
    }
}
