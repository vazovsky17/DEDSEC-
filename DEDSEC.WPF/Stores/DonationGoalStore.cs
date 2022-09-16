using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Stores
{
	public class DonationGoalStore
    {
        private readonly IDataService<DonationGoal> _dataService;

        private DonationGoal? _currentDonationGoal;
		public DonationGoal? CurrentDonationGoal
		{
			get
			{
				return _currentDonationGoal;
			}
			set
			{
				_currentDonationGoal = value;
				DonationGoalChanged?.Invoke();
			}
		}

		public DonationGoalStore(IDataService<DonationGoal> dataService)
		{
			_dataService = dataService;
		}

		public event Action DonationGoalChanged;

		public async Task Load()
		{
			var donationGoal = await _dataService.GetAll();
			CurrentDonationGoal = donationGoal.FirstOrDefault();
		}

        public async Task Add(DonationGoal donationGoal)
        {
            var donationGoals = await _dataService.GetAll();
            foreach (var goal in donationGoals)
            {
                await Delete(goal);
            }
            await _dataService.Create(donationGoal);
            CurrentDonationGoal = donationGoal;
        }
        public async Task Update(DonationGoal donationGoal)
        {
            await _dataService.Update(donationGoal.Id, donationGoal);
            CurrentDonationGoal = donationGoal;
        }
        public async Task Delete(DonationGoal donationGoal)
        {
            await _dataService.Delete(donationGoal.Id);
            CurrentDonationGoal = null;
        }
    }
}
