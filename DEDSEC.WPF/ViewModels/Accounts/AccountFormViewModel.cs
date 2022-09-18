using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Accounts
{
    public class AccountFormViewModel : ViewModelBase
    {
        #region Properties
        private string _nickname;
        public string Nickname
        {
            get
            {
                return _nickname;
            }
            set
            {
                _nickname = value;
                OnPropertyChanged(nameof(Nickname));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private int _age;
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        private string _aboutMe;
        public string AboutMe
        {
            get
            {
                return _aboutMe;
            }
            set
            {
                _aboutMe = value;
                OnPropertyChanged(nameof(AboutMe));
            }
        }

        private bool _isVisited;
        public bool IsVisited
        {
            get
            {
                return _isVisited;
            }
            set
            {
                _isVisited = value;
                OnPropertyChanged(nameof(IsVisited));
            }
        }
        #endregion

        #region Commands
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }
        #endregion

        public AccountFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }
    }
}
