using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Commands.Authorization;
using DEDSEC.WPF.Services.Authenticator;
using DEDSEC.WPF.Services.Navigation;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Authorization
{
    public class LoginViewModel : ViewModelBase
    {
        #region Properties
        private string _nickname = string.Empty;
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

        private string _password = string.Empty;
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

        private bool _isAdmin = false;
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

        private string _administrationCode = string.Empty;
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
        #endregion

        #region ErrorMessage
        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }
        #endregion

        public bool CanLogin => !string.IsNullOrEmpty(Nickname) && !string.IsNullOrEmpty(Password);

        #region Commands
        public ICommand LoginCommand { get; }
        public ICommand NavigateRegisterCommand { get; }
        #endregion

        public LoginViewModel(IAuthenticatorService authenticatorService,
            INavigationService loginNavigationService,
            INavigationService registerNavigationService)
        {
            ErrorMessageViewModel = new();

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

