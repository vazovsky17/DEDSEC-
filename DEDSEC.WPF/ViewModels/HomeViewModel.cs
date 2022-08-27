using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services.Navigation;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public string WelcomeMessage => "Welcome to Dedsec";

        public ICommand NavigateLoginCommand { get; }

        public HomeViewModel(INavigationService loginNavigationService)
        {
            NavigateLoginCommand = new NavigateCommand(loginNavigationService);
        }
    }
}
