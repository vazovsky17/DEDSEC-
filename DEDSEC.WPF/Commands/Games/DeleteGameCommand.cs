using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Stores;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands.Games
{
    public class DeleteGameCommand : AsyncCommandBase
    {
        private readonly Game _game;
        private readonly GamesStore _gamesStore;

        public DeleteGameCommand(Game game,
            GamesStore gamesStore)
        {
            _game = game;
            _gamesStore = gamesStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _gamesStore.Delete(_game);
        }
    }
}
