using DEDSEC.Domain.Models;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels;
using System;
using System.Collections.Generic;

namespace DEDSEC.WPF.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _viewModel;
        private readonly AccountStore _accountStore;
        private readonly INavigationService _navigationService;

        public LoginCommand(LoginViewModel viewModel, AccountStore accountStore, INavigationService navigationService)
        {
            _viewModel = viewModel;
            _accountStore = accountStore;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            Account account = new Account()
            {
                Id = Guid.NewGuid(),
                AccountHolder = new User()
                {
                    Id = Guid.NewGuid(),
                    Nickname = _viewModel.Nickname,
                    Password = _viewModel.Password,
                },
                Name = "MARINA",
                Age = 23,
                AboutMe = "Android developer",
                IsVisited = true,
                FavoriteGames = new List<Game>()
            };
            _accountStore.CurrentAccount = account;

            _navigationService.Navigate();
        }
    }
}
