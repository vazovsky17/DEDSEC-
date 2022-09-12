using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Players;
using System;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands.Players
{
    public class EditPlayerCommand : AsyncCommandBase
    {
        private readonly EditPlayerViewModel _editPlayerViewModel;
        private readonly PlayersStore _playersStore;
        private readonly ModalNavigationStore _modalStore;

        public EditPlayerCommand(EditPlayerViewModel editPlayerViewModel,
            PlayersStore playersStore,
            ModalNavigationStore modalStore)
        {
            _editPlayerViewModel = editPlayerViewModel;
            _playersStore = playersStore;
            _modalStore = modalStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var player = new Account()
            {
                Id = _editPlayerViewModel.Player?.Id ?? Guid.NewGuid(),
                AccountHolder = new User()
                {
                    Id = _editPlayerViewModel.Player?.AccountHolder?.Id ?? Guid.NewGuid(),
                    Nickname = _editPlayerViewModel.AccountFormViewModel.Nickname,
                    Password = _editPlayerViewModel.AccountFormViewModel.Password,
                    IsAdmin = _editPlayerViewModel.Player?.AccountHolder?.IsAdmin ?? false,
                },
                Name = _editPlayerViewModel.AccountFormViewModel.Name,
                Age = _editPlayerViewModel.AccountFormViewModel.Age,
                AboutMe = _editPlayerViewModel.AccountFormViewModel.AboutMe,
                IsVisited = _editPlayerViewModel.AccountFormViewModel.IsVisited,
                FavoriteGames = _editPlayerViewModel.Player?.FavoriteGames ?? new()
            };

            if (player != null)
            {
                await _playersStore.Update(player).ContinueWith(task =>
                {
                    if (task.IsCompleted)
                    {
                        _modalStore.Close();
                    }
                });

            }
        }
    }
}
