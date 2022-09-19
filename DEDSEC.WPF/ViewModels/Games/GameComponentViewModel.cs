using DEDSEC.Domain.Models;
using DEDSEC.WPF.Extensions;
using DEDSEC.WPF.Stores;

namespace DEDSEC.WPF.ViewModels.Games
{
    public class GameComponentViewModel : ViewModelBase
    {
        public AccountStore AccountStore { get; }
        private readonly ModalNavigationStore _modalNavigationStore;

        public Game Game { get; }

        #region Bindings
        public string Name => Game.SetNameDisplay();
        public string Description => Game.SetNameDescription();
        public string PlayersCount => Game.SetCountPlayersDisplay();
        public string LinkHobbyGames => Game.SetLinkDisplay();
        #endregion

        public GameComponentViewModel(Game game,
            AccountStore accountStore,
            ModalNavigationStore modalNavigationStore)
        {
            Game = game;
            AccountStore = accountStore;
            _modalNavigationStore = modalNavigationStore;
        }

    }
}
