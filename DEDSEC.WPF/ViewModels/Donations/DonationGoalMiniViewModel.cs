using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using System;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Donations
{
    public class DonationGoalMiniViewModel : ViewModelBase
    {
        private readonly DonationGoalStore _donationGoalStore;
        private readonly AccountStore _accountStore;

        public ICommand AddDonationCommand { get; }
        public ICommand NavigateDonationGoalCommand { get; }
        public bool IsAdmin => _accountStore?.IsAdmin ?? false;

        public DonationGoal DonationGoal { get; }
        public Guid Id => DonationGoal?.Id ?? Guid.NewGuid();
        public string Title => DonationGoal?.Title ?? "Неизвестно";
        public string Description => DonationGoal?.Description ?? "Неизвестно";
        public int CurrentValue => DonationGoal?.CurrentValue ?? 0;
        public int TargetValue => DonationGoal?.TargetValue ?? 100;
        public int Progress => CurrentValue * 100 / TargetValue;
        public string Targets => CurrentValue + "/" + TargetValue;

        public DonationGoalMiniViewModel(DonationGoalStore donationGoalStore, AccountStore accountStore, INavigationService addDonationNavigationService, INavigationService donationGoalNavigationService)
        {
            _donationGoalStore = donationGoalStore;
            _accountStore = accountStore;
            AddDonationCommand = new NavigateCommand(addDonationNavigationService);
            NavigateDonationGoalCommand = new NavigateCommand(donationGoalNavigationService);
        }
    }
}
