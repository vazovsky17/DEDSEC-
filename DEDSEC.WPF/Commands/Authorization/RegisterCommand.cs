using DEDSEC.Domain.Exceptions;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Services.Authenticator;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.ViewModels.Authorization;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands.Authorization
{
    public class RegisterCommand : AsyncCommandBase
    {
        private readonly RegisterViewModel _registerViewModel;
        private readonly IAuthenticatorService _authenticatorService;
        private readonly INavigationService _navigationService;

        public RegisterCommand(RegisterViewModel registerViewModel,
            IAuthenticatorService authenticatorService,
            INavigationService navigationService)
        {
            _registerViewModel = registerViewModel;
            _authenticatorService = authenticatorService;
            _navigationService = navigationService;

            _registerViewModel.PropertyChanged += RegisterViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _registerViewModel.CanRegister && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _registerViewModel.ErrorMessage = string.Empty;

            try
            {
                await _authenticatorService.Register(
                    _registerViewModel.Nickname,
                    _registerViewModel.Password,
                    _registerViewModel.ConfirmPassword,
                    _registerViewModel.IsAdmin,
                    _registerViewModel.AdministrationCode);
                _navigationService.Navigate();
            }
            catch (NicknameAlreadyExistsException)
            {
                _registerViewModel.ErrorMessage = "Пароли не совпадают";
            }
            catch (PasswordsDoNotMatchException)
            {
                _registerViewModel.ErrorMessage = "Пароли не совпадают";
            }
            catch (AdministrationCodeInvalidException)
            {
                _registerViewModel.ErrorMessage = "Неверно введен код администрации.";
            }
            catch (Exception e)
            {
                _registerViewModel.ErrorMessage = $"Что-то пошло совсем не так.\nОшибка:{e}";
            }
        }

        private void RegisterViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(RegisterViewModel.CanRegister))
            {
                OnCanExecuteChanged();
            }
        }
    }
}