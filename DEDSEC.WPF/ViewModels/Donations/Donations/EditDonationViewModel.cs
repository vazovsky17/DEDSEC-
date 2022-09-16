using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Commands.Donations;
using DEDSEC.WPF.Stores;

namespace DEDSEC.WPF.ViewModels.Donations.Donations
{
    public class EditDonationViewModel : ViewModelBase
    {
        public DonationFormViewModel DonationFormViewModel { get; }
        public Donation Donation { get; }

        public EditDonationViewModel(Donation donation,
            DonationGoalStore donationGoalStore,
            ModalNavigationStore modalNavigationStore)
        {
            Donation = donation;
            var SubmitCommand = new EditDonationCommand(this, donationGoalStore, modalNavigationStore);
            var CancelCommand = new CloseModalCommand(modalNavigationStore);

            DonationFormViewModel = new DonationFormViewModel(SubmitCommand, CancelCommand)
            {
                DonatValue = Donation.Value
            };
        }
    }
}
