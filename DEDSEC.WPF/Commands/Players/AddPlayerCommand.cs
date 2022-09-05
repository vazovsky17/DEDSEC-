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
                Name = _addPlayerViewModel.Name,
                AccountHolder = new User()
                {
                    Id = Guid.NewGuid(),
                    Nickname = _addPlayerViewModel.Nickname,
                    Password = _addPlayerViewModel.Password,
                    IsAdmin = _addPlayerViewModel.IsAdmin,
                },
                Age = _addPlayerViewModel.Age,
                AboutMe = _addPlayerViewModel.AboutMe,
                IsVisited = _addPlayerViewModel.IsVisited,
                FavoriteGames = new List<Game>()
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
