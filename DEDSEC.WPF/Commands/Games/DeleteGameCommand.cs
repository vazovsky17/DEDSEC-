using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Stores;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands.Games
{
    public class DeleteGameCommand : AsyncCommandBase
    {
        private readonly GamesStore _gamesStore;
        private readonly Game _game;

        public DeleteGameCommand(GamesStore gamesStore,
            Game game)
        {
            _gamesStore = gamesStore;
            _game = game;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _gamesStore.Delete(_game);
        }
    }
}
