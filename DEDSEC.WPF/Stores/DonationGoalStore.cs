using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Stores
{
    public class DonationGoalStore
    {
        private readonly IDataService<DonationGoal> _dataService;

        private DonationGoal? _donationGoal;
        public DonationGoal? DonationGoal
        {
            get => _donationGoal;
            set
            {
                _donationGoal = value;
            }
        }

        public bool HasDonationGoal => _donationGoal != null;

        private readonly List<Donation> _donations;
        public IEnumerable<Donation> Donations => _donations;

        public event Action DonationGoalLoaded;
        public event Action<DonationGoal> DonationGoalAdded;
        public event Action<DonationGoal> DonationGoalUpdated;
        public event Action<Guid> DonationGoalDeleted;
        public event Action<Donation> DonationAdded;
        public event Action<Donation> DonationUpdated;
        public event Action<Guid> DonationDeleted;

        public DonationGoalStore(IDataService<DonationGoal> dataService)
        {
            _donations = new();
            _dataService = dataService;
        }

        public async Task Load()
        {
            var donationGoals = await _dataService.GetAll();
            _donationGoal = donationGoals.FirstOrDefault();
            DonationGoalLoaded?.Invoke();
        }

        public async Task Add(DonationGoal donationGoal)
        {
            var donationGoals = await _dataService.GetAll();
            foreach (var goal in donationGoals)
            {
                await Delete(goal);
            }
            await _dataService.Create(donationGoal);
            _donationGoal = donationGoal;
            DonationGoalAdded?.Invoke(donationGoal);
        }

        public async Task Update(DonationGoal donationGoal)
        {
            await _dataService.Update(donationGoal.Id, donationGoal);
            _donationGoal = donationGoal;
            DonationGoalUpdated?.Invoke(donationGoal);
        }
        public async Task Delete(DonationGoal donationGoal)
        {
            await _dataService.Delete(donationGoal.Id);
            _donationGoal = null;
            DonationGoalDeleted?.Invoke(donationGoal.Id);
        }

        public async Task AddDonation(Donation donation)
        {
            var donationGoal = _donationGoal;
            if (donationGoal != null)
            {
                donationGoal.Donations.Add(donation);
                await _dataService.Update(donationGoal.Id, donationGoal);
                _donations.Add(donation);
                DonationAdded?.Invoke(donation);
            }
        }

        public async Task UpdateDonation(Donation donation)
        {
            var donationGoal = _donationGoal;
            if (donationGoal != null)
            {
                donationGoal.Donations.Add(donation);
                await _dataService.Update(donationGoal.Id, donationGoal);
                _donations.Add(donation);
                DonationUpdated?.Invoke(donation);
            }
        }

        public async Task DeleteDonation(Donation donation)
        {
            var donationGoal = _donationGoal;
            if (donationGoal != null)
            {
                donationGoal.Donations.Remove(donation);
                await _dataService.Update(donationGoal.Id, donationGoal);
                _donations.Remove(donation);
                DonationDeleted?.Invoke(donation.Id);
            }
        }
    }
}
