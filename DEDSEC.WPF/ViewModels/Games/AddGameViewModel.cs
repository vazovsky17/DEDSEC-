using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Commands.Games;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Forms;

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
                MinCountPlayers = 0,
                MaxCountPlayers = 4
            };
        }
    }
}
