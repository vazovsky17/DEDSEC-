using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Forms
{
    public class DonationFormViewModel : ViewModelBase
    {
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

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public DonationFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }
    }
}
