using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Commands.Donations;
using DEDSEC.WPF.Extensions;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Donations.Donations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Donations.DonationGoals
{
    public class DonationGoalViewModel : ViewModelBase
    {
        private readonly DonationGoalStore _donationGoalStore;
        private readonly AccountStore _accountStore;
        public bool IsAdmin => _accountStore.IsAdmin;

        public DonationGoal DonationGoal {get;private set;}

        #region Bindings
        public string Title => DonationGoal.SetTitleDisplay();
        public string Description => DonationGoal.SetDescriptionDisplay();
        public int CurrentValue => DonationGoal?.CurrentValue ?? 00;
        public int TargetValue => DonationGoal?.TargetValue ?? 100;
        public int Progress => CurrentValue * 100 / TargetValue;
        public string Targets => DonationGoal.SetTargetDisplay();

        private readonly ObservableCollection<DonationViewModel> _donationViewModels;
        public IEnumerable<DonationViewModel> DonationViewModels => _donationViewModels;
        public string DonationsViewModelsCountDisplay => DonationViewModels.SetDonationViewModelsCountDisplay();
        #endregion

        #region Commands
        public ICommand EditDonationGoalCommand { get; }
        public ICommand DeleteDonationGoalCommand { get; }
        
        public ICommand AddDonationCommand { get; }
        #endregion


        public DonationGoalViewModel(DonationGoal donationGoal,
            DonationGoalStore donationGoalStore,
            AccountStore accountStore,
            ModalNavigationStore modalNavigationStore,
            INavigationService addDonationNavigationService)
        {
            DonationGoal = donationGoal;
            _donationGoalStore = donationGoalStore;
            _donationViewModels = new();

            EditDonationGoalCommand = new OpenEditDonationGoalCommand(this, donationGoalStore, modalNavigationStore);
            DeleteDonationGoalCommand = new DeleteDonationGoalCommand(donationGoalStore, DonationGoal);

            AddDonationCommand = new NavigateCommand(addDonationNavigationService);

            Load();
            _donationGoalStore.DonationGoalChanged += DonationGoalStore_Changed;

            //_donationGoalStore.DonationGoalAdded += DonationGoalStore_Changed;
            //_donationGoalStore.DonationGoalUpdated += DonationGoalStore_Changed;
            //_donationGoalStore.DonationGoalDeleted += DonationGoalStore_Deleted;

            //_donationGoalStore.DonationAdded += DonationGoalStore_DonationAdded;
            //_donationGoalStore.DonationUpdated += DonationGoalStore_DonationUpdated;
            //_donationGoalStore.DonationDeleted += DonationGoalStore_DonationDeleted;
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
            //OnPropertyChanged(nameof(HasDonationGoal));
            //OnPropertyChanged(nameof(CanAddDonationGoal));
            //OnPropertyChanged(nameof(CanEditDonationGoal));
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
