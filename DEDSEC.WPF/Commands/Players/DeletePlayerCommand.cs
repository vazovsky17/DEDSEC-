using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands.Players
{
    public class DeletePlayerCommand : AsyncCommandBase
    {
        private readonly IAuthenticatorService _authenticatorService;
        private readonly INavigationService _logoutNavigationService;
        private readonly PlayersStore _playersStore;
        private readonly Account _player;

        public DeletePlayerCommand(IAuthenticatorService authenticatorService,
            INavigationService logoutNavigationService,
            PlayersStore playersStore,
            Account player)
        {
            _authenticatorService = authenticatorService;
            _logoutNavigationService = logoutNavigationService;
            _playersStore = playersStore;
            _player = player;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _playersStore.Delete(_player).ContinueWith(task =>
            {
                if (task.IsCompleted && _player.Id == _authenticatorService.CurrentAccount?.Id)
                {
                    _logoutNavigationService.Navigate();
                    _authenticatorService.Logout();
                }
            });
        }
    }
}
