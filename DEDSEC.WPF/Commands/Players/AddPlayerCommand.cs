using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Players;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands.Players
{
    public class AddPlayerCommand : AsyncCommandBase
    {
        private readonly AddPlayerViewModel _addPlayerViewModel;
        private readonly PlayersStore _playersStore;
        private readonly INavigationService _navigationService;

        public AddPlayerCommand(AddPlayerViewModel addPlayerViewModel,
            PlayersStore playersStore,
            INavigationService navigationService)
        {
            _addPlayerViewModel = addPlayerViewModel;
            _playersStore = playersStore;
            _navigationService = navigationService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var player = new Account()
            {
                Id = Guid.NewGuid(),
                Name = _addPlayerViewModel.AccountFormViewModel.Name,
                AccountHolder = new User()
                {
                    Id = Guid.NewGuid(),
                    Nickname = _addPlayerViewModel.AccountFormViewModel.Nickname,
                    Password = _addPlayerViewModel.AccountFormViewModel.Password,
                    IsAdmin = false,
                },
                Age = _addPlayerViewModel.AccountFormViewModel.Age,
                AboutMe = _addPlayerViewModel.AccountFormViewModel.AboutMe,
                IsVisited = _addPlayerViewModel.AccountFormViewModel.IsVisited,
                FavoriteGames = new()
            };
            await _playersStore.Add(player).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    _navigationService.Navigate();
                }
            });
        }
    }
}
