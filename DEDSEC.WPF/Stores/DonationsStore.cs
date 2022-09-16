using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Stores
{
    public class DonationsStore
    {
        private readonly IDataService<DonationGoal> _dataService;
        private readonly DonationGoalStore _donationGoalStore;

        public DonationGoal? DonationGoal => _donationGoalStore?.CurrentDonationGoal;
        private  List<Donation> _donations => _donationGoalStore.CurrentDonationGoal?.Donations ?? new();
        public IEnumerable<Donation> Donations => _donations;

        public DonationsStore(DonationGoalStore donationGoalStore)
        {
            _donationGoalStore = donationGoalStore;

        }

        public event Action<Donation> DonationAdded;
        public event Action<Donation> DonationUpdated;
        public event Action<Guid> DonationDeleted;

        public async Task AddDonation(Donation donation)
        {
            var donationGoal = DonationGoal;
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
            var donationGoal = DonationGoal;
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
            var donationGoal = DonationGoal;
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
