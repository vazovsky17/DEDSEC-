using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Games;

namespace DEDSEC.WPF.Commands.Games
{
    public class ShowGameCommand : CommandBase
    {
        private readonly Game _game;
        private readonly ModalNavigationStore _modalNavigationStore;

        public ShowGameCommand(Game game,
            ModalNavigationStore modalNavigationStore)
        {
            _game = game;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            GameComponentViewModel gameComponentViewModel = new GameComponentViewModel(
                _game,_modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = gameComponentViewModel;
        }
    }
}
