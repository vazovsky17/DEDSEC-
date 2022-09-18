using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Commands.Authorization;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Services.Navigation;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Authorization
{
    public class RegisterViewModel : ViewModelBase
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
                OnPropertyChanged(nameof(CanRegister));
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
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string _confirmPassword = string.Empty;
        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
                OnPropertyChanged(nameof(CanRegister));
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

        public bool CanRegister => !string.IsNullOrEmpty(Nickname) &&
            !string.IsNullOrEmpty(Password) &&
            !string.IsNullOrEmpty(ConfirmPassword);


        #region Commands
        public ICommand RegisterCommand { get; }
        public ICommand NavigateLoginCommand { get; }
        #endregion

        #region ErrorMessage
        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }
        #endregion

        public RegisterViewModel(IAuthenticatorService authenticatorService,
            INavigationService registerNavigationService,
            INavigationService loginNavigationService)
        {
            ErrorMessageViewModel = new();

            RegisterCommand = new RegisterCommand(this, authenticatorService, registerNavigationService);
            NavigateLoginCommand = new NavigateCommand(loginNavigationService);
        }

        public override void Dispose()
        {
            ErrorMessageViewModel.Dispose();

            base.Dispose();
        }
    }
}
