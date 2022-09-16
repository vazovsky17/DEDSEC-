using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Donations;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using System.Linq;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Donations.DonationGoals
{
    public class DonationGoalViewModel : ViewModelBase
    {
        public DonationGoal DonationGoal { get; private set; }

        public string Title => DonationGoal?.Title ?? string.Empty;
        public string Description => DonationGoal?.Description ?? string.Empty;
        public int CurrentValue => DonationGoal?.CurrentValue ?? 00;
        public int TargetValue => DonationGoal?.TargetValue ?? 100;
        public int Progress => CurrentValue * 100 / TargetValue;
        public string Targets => CurrentValue + "/" + TargetValue;
        //public string DonationsViewModelsCountDisplay => setDonationViewModelsCountDisplay();

        public ICommand EditDonationGoalCommand { get; }
        public ICommand DeleteDonationGoalCommand { get; }


        public DonationGoalViewModel(DonationGoal donationGoal,
            DonationGoalStore donationGoalStore,
            ModalNavigationStore modalNavigationStore)
        {
            DonationGoal = donationGoal;

            EditDonationGoalCommand = new OpenEditDonationGoalCommand(this, donationGoalStore, modalNavigationStore);
            DeleteDonationGoalCommand = new DeleteDonationGoalCommand(donationGoalStore, DonationGoal);
        }


    }
}
