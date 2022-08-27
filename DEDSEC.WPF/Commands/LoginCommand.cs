using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace DEDSEC.WPF.Commands
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly IDataService<Account> _dataService;
        private readonly LoginViewModel _viewModel;
        private readonly AccountStore _accountStore;
        private readonly INavigationService _navigationService;

        public LoginCommand(LoginViewModel viewModel, IDataService<Account> dataService, AccountStore accountStore, INavigationService navigationService)
        {
            _viewModel = viewModel;
            _dataService = dataService;
            _accountStore = accountStore;
            _navigationService = navigationService;
        }
       
        public override async Task ExecuteAsync(object parameter)
        {
            var account = new Account()
            {
                Id = Guid.NewGuid(),
                AccountHolder = new User()
                {
                    Id = Guid.NewGuid(),
                    Nickname = _viewModel.Nickname,
                    Password = _viewModel.Password,
                    IsAdmin = _viewModel.IsAdmin,
                },
                Name = "",
                Age = 0,
                AboutMe = "",
                IsVisited = false,
                FavoriteGames = new List<Game>()
            };

            await _dataService.Create(account).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    _accountStore.CurrentAccount = account;
                    _navigationService.Navigate();
                }
            });
        }
    }
}
