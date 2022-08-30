using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Authorization
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
                OnPropertyChanged(nameof(CanLogin));
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
                OnPropertyChanged(nameof(CanLogin));
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

        private string _administrationCode;
        public string AdministrationCode
        {
            get
            {
                return _administrationCode;
            }
            set
            {
                _administrationCode = value;
                OnPropertyChanged(nameof(AdministrationCode));
            }
        }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public bool CanLogin => !string.IsNullOrEmpty(Nickname) && !string.IsNullOrEmpty(Password);

        public ICommand LoginCommand { get; }
        public ICommand NavigateRegisterCommand { get; }

        public LoginViewModel(IAuthenticatorService authenticatorService, INavigationService loginNavigationService, INavigationService registerNavigationService)
        {
            ErrorMessageViewModel = new MessageViewModel();
            LoginCommand = new LoginCommand(this, authenticatorService, loginNavigationService);
            NavigateRegisterCommand = new NavigateCommand(registerNavigationService);
        }

        public override void Dispose()
        {
            ErrorMessageViewModel.Dispose();
            base.Dispose();
        }
    }
}

