using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Services.Authenticator;
using DEDSEC.WPF.Stores;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands.Games
{
    public class AddToFavoritesGamesCommand : AsyncCommandBase
    {
        private readonly Game _game;
        private readonly GamesStore _gamesStore;
        private readonly IAuthenticatorService _authenticatorService;

        public AddToFavoritesGamesCommand(Game game,
            GamesStore gamesStore,
            IAuthenticatorService authenticatorService)
        {
            _game = game;
            _gamesStore = gamesStore;
            _authenticatorService = authenticatorService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var account = _authenticatorService.CurrentAccount;
            if (account != null)
            {
                await _gamesStore.AddToFavorite(_game);
            }
        }
    }
}
