using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Games;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Donations
{
    public class DonationGoalViewModel : ViewModelBase
    {
        private readonly DonationGoalStore _donationGoalStore;
        private readonly AccountStore _accountStore;
        public bool IsAdmin => _accountStore?.IsAdmin ?? false;

        private readonly ObservableCollection<DonationViewModel> _donationViewModels;
        public IEnumerable<DonationViewModel> DonationViewModels => _donationViewModels;

        public DonationGoal? DonationGoal => _donationGoalStore?.DonationGoal;
        public bool HasDonationGoal => DonationGoal != null;
        public bool DonationGoalMissing => !HasDonationGoal;
        public bool CanAddDonationGoal => IsAdmin && DonationGoalMissing;
        public bool CanEditDonationGoal => IsAdmin && HasDonationGoal;

        public string Title => DonationGoal?.Title ?? String.Empty;
        public string Description => DonationGoal?.Description ?? String.Empty;
        public int CurrentValue => DonationGoal?.CurrentValue ?? 00;
        public int TargetValue => DonationGoal?.TargetValue ?? 100;
        public int Progress => CurrentValue * 100 / TargetValue;
        public string Targets => CurrentValue + "/" + TargetValue;
        public string DonationsViewModelsCountDisplay => setDonationViewModelsCountDisplay();

        private string setDonationViewModelsCountDisplay()
        {
            var count = _donationViewModels.Count;
            return count + " " + GrammarDonation(count);
        }

        private string GrammarDonation(int num)
        {
            if (num % 10 == 0)
            {
                return "донатов";
            }
            else if (num % 10 == 1 && num != 11)
            {
                return "донат";
            }
            else if ((num >= 4 && num <= 2) || (num % 10 >= 4 && num % 10 <= 2 && num < 12 && num > 14))
            {
                return "доната";
            }
            else
            {
                return "донатов";
            }
        }

        public ICommand AddDonationCommand { get; }
        public ICommand AddDonationGoalCommand { get; }
        public ICommand EditDonationGoalCommand { get; }
        public ICommand DeleteDonationGoalCommand { get; }

        public DonationGoalViewModel(DonationGoalStore donationGoalStore,
            AccountStore accountStore,
            INavigationService addDonationNavigationService,
            INavigationService addDonationGoalNavigationService,
            INavigationService editDonationGoalNavigationService)
        {
            _donationGoalStore = donationGoalStore;
            _accountStore = accountStore;

            _donationViewModels = new();

            Load();
            _donationGoalStore.DonationGoalLoaded += DonationGoalStore_Changed;
            _donationGoalStore.DonationGoalAdded += DonationGoalStore_Changed;
            _donationGoalStore.DonationGoalUpdated += DonationGoalStore_Changed;
            _donationGoalStore.DonationGoalDeleted += DonationGoalStore_Deleted;
            _donationGoalStore.DonationAdded += DonationGoalStore_DonationAdded;
            _donationGoalStore.DonationUpdated += DonationGoalStore_DonationUpdated;
            _donationGoalStore.DonationDeleted += DonationGoalStore_DonationDeleted;

            AddDonationCommand = new NavigateCommand(addDonationNavigationService);
            AddDonationGoalCommand = new NavigateCommand(addDonationGoalNavigationService);
            EditDonationGoalCommand = new NavigateCommand(editDonationGoalNavigationService);
        }

        private async void Load()
        {
            await _donationGoalStore.Load();
            OnAllPropertysChanged();
        }

        private void DonationGoalStore_Changed()
        {
            OnAllPropertysChanged();
        }

        private void DonationGoalStore_Changed(DonationGoal donationGoal)
        {
            OnAllPropertysChanged();
        }

        private void DonationGoalStore_Deleted(Guid id)
        {
            OnAllPropertysChanged();
        }

        private void OnAllPropertysChanged()
        {
            OnPropertyChanged(nameof(DonationGoal));
            OnPropertyChanged(nameof(HasDonationGoal));
            OnPropertyChanged(nameof(DonationGoalMissing));
            OnPropertyChanged(nameof(CanAddDonationGoal));
            OnPropertyChanged(nameof(CanEditDonationGoal));
        }

        private void DonationGoalStore_DonationAdded(Donation donation)
        {
            AddDonationViewModel(donation);
        }

        private void DonationGoalStore_DonationUpdated(Donation donation)
        {
            DonationViewModel donationViewModel = _donationViewModels.FirstOrDefault(x => x.Id == donation.Id);

            if (donationViewModel != null)
            {
                donationViewModel.Update(donation);
            }
        }

        private void DonationGoalStore_DonationDeleted(Guid id)
        {
            DonationViewModel donationViewModel = _donationViewModels.FirstOrDefault(x => x.Id == id);

            if (donationViewModel != null)
            {
                _donationViewModels.Remove(donationViewModel);
            }
        }

        private void AddDonationViewModel(Donation donation)
        {
            var itemViewModel = new DonationViewModel(donation);
            _donationViewModels.Add(itemViewModel);
        }

        public override void Dispose()
        {
            _donationGoalStore.DonationGoalLoaded -= DonationGoalStore_Changed;
            _donationGoalStore.DonationGoalAdded -= DonationGoalStore_Changed;
            _donationGoalStore.DonationGoalUpdated -= DonationGoalStore_Changed;
            _donationGoalStore.DonationGoalDeleted -= DonationGoalStore_Deleted;
            _donationGoalStore.DonationAdded -= DonationGoalStore_DonationAdded;
            _donationGoalStore.DonationUpdated -= DonationGoalStore_DonationUpdated;
            _donationGoalStore.DonationDeleted -= DonationGoalStore_DonationDeleted;

            base.Dispose();
        }
    }
}
