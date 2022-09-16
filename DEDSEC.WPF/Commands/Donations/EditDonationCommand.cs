using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Donations.Donations;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands.Donations
{
    public class EditDonationCommand : AsyncCommandBase
    {
        private readonly EditDonationViewModel _editDonationViewModel;
        private readonly DonationsStore _donationsStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public EditDonationCommand(EditDonationViewModel editDonationViewModel,
            DonationsStore donationsStore,
            ModalNavigationStore modalNavigationStore)
        {
            _editDonationViewModel = editDonationViewModel;
            _donationsStore = donationsStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var donation = new Donation()
            {
                Id = _editDonationViewModel.Donation.Id,
                Donater = _editDonationViewModel.Donation.Donater,
                Value = _editDonationViewModel.DonationFormViewModel.DonatValue
            };
            if (donation != null)
            {
                await _donationsStore.UpdateDonation(donation).ContinueWith(task =>
                {
                    if (task.IsCompleted)
                    {
                        _modalNavigationStore.Close();
                    }
                });
            }
        }
    }
}
