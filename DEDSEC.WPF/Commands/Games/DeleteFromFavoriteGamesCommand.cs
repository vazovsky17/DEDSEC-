using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands.Games
{
    public class DeleteFromFavoriteGamesCommand : AsyncCommandBase
    {
        private readonly Game _game;
        private readonly AccountStore _accountStore;
        private readonly IAuthenticatorService _authenticatorService;

        public DeleteFromFavoriteGamesCommand(Game game,
            AccountStore accountStore,
            IAuthenticatorService authenticatorService)
        {
            _game = game;
            _accountStore = accountStore;
            _authenticatorService = authenticatorService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var account = _authenticatorService.CurrentAccount;
            if (account != null)
            {
                await _accountStore.DeleteFromFavoriteGames(_game);
            }
        }
    }
}
