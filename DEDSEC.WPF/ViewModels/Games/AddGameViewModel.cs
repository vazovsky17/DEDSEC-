using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Commands.Games;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;

namespace DEDSEC.WPF.ViewModels.Games
{
    public class AddGameViewModel : ViewModelBase
    {
        public GameFormViewModel GameFormViewModel { get; }

        public AddGameViewModel(GamesStore gamesStore,
            INavigationService closeNavigationService)
        {
            var submitCommand = new AddGameCommand(this, gamesStore, closeNavigationService);
            var cancelCommand = new NavigateCommand(closeNavigationService);

            GameFormViewModel = new GameFormViewModel(submitCommand, cancelCommand)
            {
                Name = string.Empty,
                Description = string.Empty,
                MinCountPlayers = 0,
                MaxCountPlayers = 4,
                LinkHobbyGames = string.Empty
            };
        }
    }
}
