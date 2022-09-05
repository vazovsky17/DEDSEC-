using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services.Authentification;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Commands.Accounts;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Services.Navigation;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Accounts
{
    public class EditAccountViewModel : ViewModelBase
    {
        public static Account? CurrentAccount { get;private set; }

        private string _nickname = CurrentAccount?.AccountHolder.Nickname ?? string.Empty;
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

        private string _password = CurrentAccount?.AccountHolder.Password ?? string.Empty;
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

        private string _name = CurrentAccount?.Name ?? string.Empty;
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

        private int _age = CurrentAccount?.Age ?? 0;
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

        private string _aboutMe = CurrentAccount?.AboutMe ?? string.Empty;
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

        private bool _isVisited = CurrentAccount?.IsVisited ?? false;
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

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public EditAccountViewModel(IAccountService dataService, IAuthenticatorService authenticatorService, INavigationService closeNavigationService)
        {
            CurrentAccount = authenticatorService.CurrentAccount;

            SubmitCommand = new EditAccountCommand(this, dataService, authenticatorService, closeNavigationService);
            CancelCommand = new NavigateCommand(closeNavigationService);
        }
    }
}
