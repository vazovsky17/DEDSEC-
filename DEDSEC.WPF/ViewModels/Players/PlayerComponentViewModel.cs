using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Extensions;
using DEDSEC.WPF.Stores;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Players
{
    public class PlayerComponentViewModel : ViewModelBase
    {
        public Account Player { get; }

        #region Bindings
        public string Nickname => Player.SetNicknameDisplay();
        public string Name => Player.SetNameDisplay();
        public string Age => Player.SetAgeDisplay();
        public string AboutMe => Player.SetAboutMeDisplay();
        public bool IsVisited => Player.IsVisited;
        #endregion

        #region
        public ICommand CloseCommand { get; }
        #endregion

        public PlayerComponentViewModel(Account player,
            ModalNavigationStore modalNavigationStore)
        {
            Player = player;

            CloseCommand = new CloseModalCommand(modalNavigationStore);
        }
    }
}
