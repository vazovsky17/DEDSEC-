using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
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

        private bool _isAdmin;
        public bool IsAdmin
        {
            get
            {
                return _isAdmin;
            }
            set
            {
                _isAdmin = value;
                OnPropertyChanged(nameof(IsAdmin));
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel(AccountStore accountStore, IDataService<Account> dataService, INavigationService loginNavigationService)
        {
            LoginCommand = new LoginCommand(this, dataService, accountStore, loginNavigationService);
        }
    }
}

