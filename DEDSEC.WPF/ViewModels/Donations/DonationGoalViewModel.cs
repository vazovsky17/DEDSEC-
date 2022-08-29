using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Donations
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
        public int Progress => CurrentValue * 100 / TargetValue;
        public string Targets => CurrentValue + "/" + TargetValue;
        public List<Donation> Donations => DonationGoal.Donations;

        public ICommand AddDonationCommand { get; }

        public DonationGoalViewModel(DonationGoalStore donationGoalStore, DonationStore donationStore, INavigationService addDonationNavigationService)
        {
            _donationGoalStore = donationGoalStore;
            _donationStore = donationStore;

            AddDonationCommand = new NavigateCommand(addDonationNavigationService);

            _donationViewModels = new ObservableCollection<DonationViewModel>();
            DonationGoal = new DonationGoal()
            {
                Id = Guid.NewGuid(),
                Title = "антикафе",
                Description = "деняки",
                CurrentValue = 400,
                TargetValue = 800,
                Donations = new List<Donation>()
            };
            _donationGoalStore.AddDonationGoal(DonationGoal);
            _donationGoalStore.DonationGoalAdded += OnDonationGoalAdded;

            Donations.ForEach(donation =>
            {
                _donationViewModels.Add(new DonationViewModel(donation));
                _donationStore.DonationAdded += OnDonationAdded;
            });

            _donationViewModels.Add(new DonationViewModel(new Donation()
            {
                Id = Guid.NewGuid(),
                Donater = new Account()
                {
                    Id = Guid.NewGuid(),
                    AccountHolder = new User()
                    {
                        Id = Guid.NewGuid(),
                        Nickname = "VAZ",
                        Password = "883306"
                    },
                    Name = "Mark",
                    Age = 23,
                    AboutMe = "about me...",
                    IsVisited = true,
                    FavoriteGames = new List<Game>(),
                },
                Value = 2400,
            }));

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
