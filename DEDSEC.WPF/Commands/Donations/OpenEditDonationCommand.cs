using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Donations.Donations;

namespace DEDSEC.WPF.Commands.Donations
{
    public class OpenEditDonationCommand : CommandBase
    {
        private readonly DonationViewModel _donationViewModel;
        private readonly DonationsStore _donationsStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenEditDonationCommand(DonationViewModel donationViewModel,
            DonationsStore donationsStore,
            ModalNavigationStore modalNavigationStore)
        {
            _donationViewModel = donationViewModel;
            _donationsStore = donationsStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            Donation donation = _donationViewModel.Donation;

            EditDonationViewModel editDonationViewModel = new EditDonationViewModel(
                donation, _donationsStore, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = editDonationViewModel;
        }
    }
}
