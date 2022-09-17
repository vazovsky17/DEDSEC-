using DEDSEC.Domain.Models;
using DEDSEC.WPF.Extensions;
using DEDSEC.WPF.Stores;
using System.Collections.Generic;
using System.Windows.Navigation;

namespace DEDSEC.WPF.ViewModels.Games
{
    public class GameComponentViewModel : ViewModelBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public Game Game { get; }
        public string Name => Game.SetNameDisplay();
        public string Description => Game.SetNameDescription();
        public string PlayersCount => Game.SetCountPlayersDisplay();
        public string LinkHobbyGames => Game.SetLinkDisplay();
        public List<Review> Reviews => Game.Reviews;

        public GameComponentViewModel(Game game,
            ModalNavigationStore modalNavigationStore)
        {
            Game = game;
            _modalNavigationStore = modalNavigationStore;
        }

        public void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.ToString());
        }
    }
}
