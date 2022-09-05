using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Stores;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands.Donations
{
    public class DeleteDonationGoalCommand : AsyncCommandBase
    {
        private readonly DonationGoalStore _donationGoalStore;
        private readonly DonationGoal _donationGoal;

        public DeleteDonationGoalCommand(DonationGoalStore donationGoalStore,
            DonationGoal donationGoal)
        {
            _donationGoalStore = donationGoalStore;
            _donationGoal = donationGoal;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _donationGoalStore.Delete(_donationGoal);
        }
    }
}
