using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Stores;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands.Games
{
    public class DeleteGameCommand : AsyncCommandBase
    {
        private readonly GamesStore _gamesStore;
        private readonly AccountStore _accountStore;
        private readonly Game _game;

        public DeleteGameCommand(GamesStore gamesStore,
            AccountStore accountStore,
            Game game)
        {
            _gamesStore = gamesStore;
            _accountStore = accountStore;
            _game = game;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _gamesStore.Delete(_game).ContinueWith(async task =>
            {
                if (task.IsCompleted)
                {
                    await _accountStore.DeleteFromFavoriteGames(_game);
                }
            });
        }
    }
}
