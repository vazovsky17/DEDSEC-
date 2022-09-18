using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Donations.DonationGoals;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Donations
{
    public class DonationsScreenViewModel : ViewModelBase
    {
        public DonationGoalStore _donationGoalStore { get; }
        public AccountStore _accountStore { get;  }
        public bool IsAdmin => _accountStore.IsAdmin;

        public DonationGoal? DonationGoal => _donationGoalStore.CurrentDonationGoal;

        #region Bool
        public bool HasDonationGoal => DonationGoal != null;
        public bool CanAddDonationGoal => IsAdmin && !HasDonationGoal;
        public bool CanEditDonationGoal => IsAdmin && HasDonationGoal;
        #endregion

        public DonationGoalViewModel DonationGoalViewModel { get; }

        #region Commands
        public ICommand AddDonationGoalCommand { get; }
        #endregion

        public DonationsScreenViewModel(DonationGoalStore donationGoalStore,
            AccountStore accountStore,
            INavigationService addDonationNavigationService,
            INavigationService addDonationGoalNavigationService,
            ModalNavigationStore modalNavigationStore)
        {
            _donationGoalStore = donationGoalStore;
            _accountStore = accountStore;

            if (HasDonationGoal)
            {
                DonationGoalViewModel = new DonationGoalViewModel(DonationGoal, donationGoalStore, accountStore, modalNavigationStore, addDonationNavigationService);
            }

            AddDonationGoalCommand = new NavigateCommand(addDonationGoalNavigationService);
        }
    }
}
