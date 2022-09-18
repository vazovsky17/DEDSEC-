using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Donations.Donations
{
    public class DonationFormViewModel : ViewModelBase
    {
        #region Properties
        private int _donatValue;
        public int DonatValue
        {
            get
            {
                return _donatValue;
            }
            set
            {
                _donatValue = value;
                OnPropertyChanged(nameof(DonatValue));
            }
        }
        #endregion

        #region Commands
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }
        #endregion

        public DonationFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }
    }
}
