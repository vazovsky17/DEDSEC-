using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels
{
    public class DonationGoalViewModel : ViewModelBase
    {
        private readonly DonationGoalStore _donationGoalStore;
        private readonly DonationStore _donationStore;
        private readonly ObservableCollection<DonationViewModel> _donationViewModels;
        public IEnumerable<DonationViewModel> DonationViewModels => _donationViewModels;

        public DonationGoal DonationGoal { get; }
        public Guid Id => DonationGoal.Id;
        public string Title => DonationGoal.Title;
        public string Description => DonationGoal.Description;
        public int CurrentValue => DonationGoal.CurrentValue;
        public int TargetValue => DonationGoal.TargetValue;
        public List<Donation> Donations => DonationGoal.Donations;

        public ICommand AddDonationCommand { get; }

        public DonationGoalViewModel(DonationGoalStore donationGoalStore, DonationStore donationStore, INavigationService addDonationNavigationService)
        {
            _donationGoalStore = donationGoalStore;
            _donationStore = donationStore;

            AddDonationCommand = new NavigateCommand(addDonationNavigationService);

            _donationViewModels = new ObservableCollection<DonationViewModel>();
            DonationGoal = new DonationGoal(
                Guid.NewGuid(),
                "антикафе","деняки",400,800,new List<Donation>());
            _donationGoalStore.AddDonationGoal(DonationGoal);
            _donationGoalStore.DonationGoalAdded += OnDonationGoalAdded;

            Donations.ForEach(donation =>
            {
                _donationViewModels.Add(new DonationViewModel(donation));
                _donationStore.DonationAdded += OnDonationAdded;
            });

            _donationViewModels.Add(new DonationViewModel(new Donation(
                Guid.NewGuid(),
                new Account(
                    Guid.NewGuid(),
                    new User(
                        Guid.NewGuid(),
                        "VAZ",
                        "883306"
                    ),
                    "Mark",
                    23,
                    "about meeeee",
                    true,
                    new List<Game>()
                    ),
                2400)));
            _donationStore.DonationAdded += OnDonationAdded;
        }

        private void OnDonationAdded(Donation donation)
        {
            _donationViewModels.Add(new DonationViewModel(donation));
        }

        private void OnDonationGoalAdded(DonationGoal donationGoal)
        {
            
        }
    }
}
