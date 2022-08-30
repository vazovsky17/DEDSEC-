using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        private DonationGoal _donationGoal;
        public DonationGoal DonationGoal => _donationGoal;
        public bool HasDonationGoal => _donationGoal != null;

        public Guid Id => DonationGoal.Id;
        public string Title => DonationGoal.Title;
        public string Description => DonationGoal.Description;
        public int CurrentValue => DonationGoal.CurrentValue;
        public int TargetValue => DonationGoal.TargetValue;
        public int Progress => CurrentValue * 100 / TargetValue;
        public string Targets => CurrentValue + "/" + TargetValue;

        public ICommand AddDonationCommand { get; }
        public ICommand AddDonationGoalCommand { get; }

        public DonationGoalViewModel(DonationGoalStore donationGoalStore, AccountStore accountStore, INavigationService addDonationNavigationService)
        {
            _donationGoalStore = donationGoalStore;
            _accountStore = accountStore;

            _donationViewModels = new ObservableCollection<DonationViewModel>();

            Load();
            _donationGoalStore.DonationGoalLoaded += DonationGoalStore_Loaded;
            _donationGoalStore.DonationGoalAdded += DonationGoalStore_Added;
            _donationGoalStore.DonationGoalUpdated += DonationGoalStore_Updated;
            _donationGoalStore.DonationGoalDeleted += DonationGoalStore_Deleted;
            _donationGoalStore.DonationAdded += DonationGoalStore_DonationAdded;
            _donationGoalStore.DonationUpdated += DonationGoalStore_DonationUpdated;
            _donationGoalStore.DonationDeleted += DonationGoalStore_DonationDeleted;

            AddDonationCommand = new NavigateCommand(addDonationNavigationService);
        }

        private async void Load()
        {
            await _donationGoalStore.Load();
        }

        private void DonationGoalStore_Loaded()
        {
            var donationGoal = _donationGoalStore.DonationGoal;
            _donationGoal = donationGoal;
            OnPropertyChanged(nameof(HasDonationGoal));
        }

        private void DonationGoalStore_Added(DonationGoal donationGoal)
        {
            _donationGoal = donationGoal;
        }

        private void DonationGoalStore_Updated(DonationGoal donationGoal)
        {
            _donationGoal = donationGoal;
        }

        private void DonationGoalStore_Deleted(Guid id)
        {
            _donationGoal = null;
        }

        private void DonationGoalStore_DonationAdded(Donation donation)
        {
            if(_d)
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
            DonationViewModel itemViewModel = new DonationViewModel(donation);
            _donationViewModels.Add(itemViewModel);
        }

        public override void Dispose()
        {
            _donationGoalStore.DonationGoalLoaded -= DonationGoalStore_Loaded;
            _donationGoalStore.DonationGoalAdded -= DonationGoalStore_Added;
            _donationGoalStore.DonationGoalUpdated -= DonationGoalStore_Updated;
            _donationGoalStore.DonationGoalDeleted -= DonationGoalStore_Deleted;
            _donationGoalStore.DonationAdded -= DonationGoalStore_DonationAdded;
            _donationGoalStore.DonationUpdated -= DonationGoalStore_DonationUpdated;
            _donationGoalStore.DonationDeleted -= DonationGoalStore_DonationDeleted;

            base.Dispose();
        }
    }
}
