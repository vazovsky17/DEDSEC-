using DEDSEC.Domain.Exceptions;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.ViewModels.Authorization;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands.Authorization
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticatorService _authenticatorService;
        private readonly INavigationService _navigationService;

        public LoginCommand(LoginViewModel loginViewModel, IAuthenticatorService authenticatorService, INavigationService navigationService)
        {
            _loginViewModel = loginViewModel;
            _authenticatorService = authenticatorService;
            _navigationService = navigationService;

            _loginViewModel.PropertyChanged += LoginViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _loginViewModel.CanLogin && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _loginViewModel.ErrorMessage = string.Empty;

            try
            {
                await _authenticatorService.Login(
                    _loginViewModel.Nickname,
                    _loginViewModel.Password,
                    _loginViewModel.IsAdmin,
                    _loginViewModel.AdministrationCode);
                _navigationService.Navigate();
            }
            catch (UserNotFoundException)
            {
                _loginViewModel.ErrorMessage = "Пользователь не найден.";
            }
            catch (PasswordInvalidException)
            {
                _loginViewModel.ErrorMessage = "Неверный пароль.";
            }
            catch (AdministratorRightsMissingException)
            {
                _loginViewModel.ErrorMessage = "У вас отсутствуют права администратора. Уберите галочку.";
            }
            catch (AdministrationCodeMissingException)
            {
                _loginViewModel.ErrorMessage = "У вас есть права администратора. Поставьте галочку и введите код.";
            }
            catch (AdministrationCodeInvalidException)
            {
                _loginViewModel.ErrorMessage = "Неверно введен код администрации.";
            }

            catch (Exception e)
            {
                _loginViewModel.ErrorMessage = $"Что-то пошло не так.\nОшибка:{e}";
            }
        }

        private void LoginViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginViewModel.CanLogin))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
