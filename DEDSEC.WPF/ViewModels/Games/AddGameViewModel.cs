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
            var SubmitCommand = new AddGameCommand(this, gamesStore, closeNavigationService);
            var CancelCommand = new NavigateCommand(closeNavigationService);

            GameFormViewModel = new GameFormViewModel(SubmitCommand, CancelCommand)
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
