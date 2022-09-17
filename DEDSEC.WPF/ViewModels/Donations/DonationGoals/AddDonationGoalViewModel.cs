using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Commands.Donations;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;

namespace DEDSEC.WPF.ViewModels.Donations.DonationGoals
{
    public class AddDonationGoalViewModel : ViewModelBase
    {
        public DonationGoalFormViewModel DonationGoalFormViewModel { get; }

        public AddDonationGoalViewModel(DonationGoalStore donationGoalStore,
            INavigationService closeNavigationService)
        {
            var SubmitCommand = new AddDonationGoalCommand(this, donationGoalStore, closeNavigationService);
            var CancelCommand = new NavigateCommand(closeNavigationService);
            DonationGoalFormViewModel = new DonationGoalFormViewModel(SubmitCommand, CancelCommand)
            {
                Title = string.Empty,
                Description = string.Empty,
                CurrentValue = 0,
                TargetValue = 100
            };
        }
    }
}
