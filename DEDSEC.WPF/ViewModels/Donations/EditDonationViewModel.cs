using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Commands.Donations;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Forms;

namespace DEDSEC.WPF.ViewModels.Donations
{
    public class EditDonationViewModel : ViewModelBase
    {
        public Donation Donation { get; }
        public DonationFormViewModel DonationFormViewModel { get; }

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
