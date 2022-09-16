using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Commands.Donations;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;

namespace DEDSEC.WPF.ViewModels.Donations.Donations
{
    public class AddDonationViewModel : ViewModelBase
    {
        public DonationFormViewModel DonationFormViewModel { get; }

        public AddDonationViewModel(DonationsStore donationsStore,
            AccountStore accountStore,
            INavigationService closeNavigationService)
        {
            var SubmitCommand = new AddDonationCommand(this, accountStore, donationsStore, closeNavigationService);
            var CancelCommand = new NavigateCommand(closeNavigationService);
            DonationFormViewModel = new DonationFormViewModel(SubmitCommand, CancelCommand)
            {
                DonatValue = 0
            };
        }
    }
}
