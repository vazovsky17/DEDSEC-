﻿using DEDSEC.Domain.Services.Authentification;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Services.Navigation;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands
{
    public class DeleteAccountCommand : AsyncCommandBase
    {
        private readonly IAccountService _dataService;
        private readonly IAuthenticatorService _authenticatorService;
        private readonly INavigationService _navigationService;

        public DeleteAccountCommand(IAccountService dataService, IAuthenticatorService authenticatorService, INavigationService navigationService)
        {
            _dataService = dataService;
            _authenticatorService = authenticatorService;
            _navigationService = navigationService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _dataService.Delete(_authenticatorService.CurrentAccount.Id).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    _authenticatorService.Logout();
                    _navigationService.Navigate();
                }
            });
        }
    }
}
