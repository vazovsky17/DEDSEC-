using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Donations.DonationGoals;
using DEDSEC.WPF.ViewModels.Donations.Donations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Donations
{
    public class DonationsScreenViewModel : ViewModelBase
    {
        private readonly DonationGoalStore _donationGoalStore;
        private readonly AccountStore _accountStore;
        public bool IsAdmin => _accountStore?.IsAdmin ?? false;

        private readonly ObservableCollection<DonationViewModel> _donationViewModels;
        public IEnumerable<DonationViewModel> DonationViewModels => _donationViewModels;
        public DonationGoal? DonationGoal => _donationGoalStore?.CurrentDonationGoal;
        public DonationGoalViewModel DonationGoalViewModel { get; }

        public bool HasDonationGoal => DonationGoal != null;
        public bool DonationGoalMissing => !HasDonationGoal;
        public bool CanAddDonationGoal => IsAdmin && DonationGoalMissing;
        public bool CanEditDonationGoal => IsAdmin && HasDonationGoal;

        public ICommand AddDonationCommand { get; }
        public ICommand AddDonationGoalCommand { get; }

        public DonationsScreenViewModel(DonationGoalStore donationGoalStore,
            AccountStore accountStore,
            INavigationService addDonationNavigationService,
            INavigationService addDonationGoalNavigationService,
            ModalNavigationStore modalNavigationStore)
        {
            _donationGoalStore = donationGoalStore;
            _accountStore = accountStore;

            _donationViewModels = new();

            Load();
            //_donationGoalStore.DonationGoalLoaded += DonationGoalStore_Changed;
            //_donationGoalStore.DonationGoalAdded += DonationGoalStore_Changed;
            //_donationGoalStore.DonationGoalUpdated += DonationGoalStore_Changed;
            //_donationGoalStore.DonationGoalDeleted += DonationGoalStore_Deleted;
            //_donationGoalStore.DonationAdded += DonationGoalStore_DonationAdded;
            //_donationGoalStore.DonationUpdated += DonationGoalStore_DonationUpdated;
            //_donationGoalStore.DonationDeleted += DonationGoalStore_DonationDeleted;

            DonationGoalViewModel = new DonationGoalViewModel(donationGoalStore.CurrentDonationGoal, donationGoalStore, modalNavigationStore);

            AddDonationCommand = new NavigateCommand(addDonationNavigationService);
            AddDonationGoalCommand = new NavigateCommand(addDonationGoalNavigationService);
        }

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
            else if (num >= 4 && num <= 2 || num % 10 >= 4 && num % 10 <= 2 && num < 12 && num > 14)
            {
                return "доната";
            }
            else
            {
                return "донатов";
            }
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
           // AddDonationViewModel(donation);
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

        private void AddDonationGoalViewModel(DonationGoal donationGoal)
        {
        }

        //private void AddDonationViewModel(Donation donation)
        //{
        //    var itemViewModel = new DonationViewModel(donation, _donationGoalStore, IsAdmin);
        //    _donationViewModels.Add(itemViewModel);
        //}

        public override void Dispose()
        {
            //_donationGoalStore.DonationGoalLoaded -= DonationGoalStore_Changed;
            //_donationGoalStore.DonationGoalAdded -= DonationGoalStore_Changed;
            //_donationGoalStore.DonationGoalUpdated -= DonationGoalStore_Changed;
            //_donationGoalStore.DonationGoalDeleted -= DonationGoalStore_Deleted;
            //_donationGoalStore.DonationAdded -= DonationGoalStore_DonationAdded;
            //_donationGoalStore.DonationUpdated -= DonationGoalStore_DonationUpdated;
            //_donationGoalStore.DonationDeleted -= DonationGoalStore_DonationDeleted;

            base.Dispose();
        }
    }
}
