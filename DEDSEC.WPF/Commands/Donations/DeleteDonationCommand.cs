using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Stores;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands.Donations
{
    public class DeleteDonationCommand : AsyncCommandBase
    {
        private readonly DonationGoalStore _donationGoalStore;
        private readonly Donation _donation;

        public DeleteDonationCommand(DonationGoalStore donationGoalStore,
            Donation donation)
        {
            _donationGoalStore = donationGoalStore;
            _donation = donation;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _donationGoalStore.DeleteDonation(_donation);
        }
    }
}
