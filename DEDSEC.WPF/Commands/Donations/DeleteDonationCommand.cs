using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Stores;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands.Donations
{
    public class DeleteDonationCommand : AsyncCommandBase
    {
        private readonly DonationsStore _donationsStore;
        private readonly Donation _donation;

        public DeleteDonationCommand(DonationsStore donationsStore,
            Donation donation)
        {
            _donationsStore = donationsStore;
            _donation = donation;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _donationsStore.DeleteDonation(_donation);
        }
    }
}
