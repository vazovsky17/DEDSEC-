using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Extensions;
using DEDSEC.WPF.Stores;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Games
{
    public class GameComponentViewModel : ViewModelBase
    {
        public Game Game { get; }

        #region Bindings
        public string Name => Game.SetNameDisplay();
        public string Description => Game.SetNameDescription();
        public string PlayersCount => Game.SetCountPlayersDisplay();
        public string LinkHobbyGames => Game.SetLinkDisplay();
        #endregion

        #region
        public ICommand CloseCommand { get; }
        #endregion

        public GameComponentViewModel(Game game,
            ModalNavigationStore modalNavigationStore)
        {
            Game = game;

            CloseCommand = new CloseModalCommand(modalNavigationStore);
        }
    }
}
