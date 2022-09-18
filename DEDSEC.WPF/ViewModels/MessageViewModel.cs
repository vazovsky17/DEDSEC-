namespace DEDSEC.WPF.ViewModels
{
    public class MessageViewModel : ViewModelBase
    {
        #region Properties
        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
                OnPropertyChanged(nameof(HasMessage));
            }
        }
        #endregion

        public bool HasMessage => !string.IsNullOrEmpty(Message);
    }
}
