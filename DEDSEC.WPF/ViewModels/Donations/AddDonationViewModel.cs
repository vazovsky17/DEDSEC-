using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Commands.Donations;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Forms;

namespace DEDSEC.WPF.ViewModels.Donations
{
    public class AddDonationViewModel : ViewModelBase
    {
        public DonationFormViewModel DonationFormViewModel { get; }

        public AddDonationViewModel(DonationGoalStore donationGoalStore,
            AccountStore accountStore,
            INavigationService closeNavigationService)
        {
            var SubmitCommand = new AddDonationCommand(this, accountStore, donationGoalStore, closeNavigationService);
            var CancelCommand = new NavigateCommand(closeNavigationService);
            DonationFormViewModel = new DonationFormViewModel(SubmitCommand, CancelCommand)
            {
                DonatValue = 0
            };
        }
    }
}
