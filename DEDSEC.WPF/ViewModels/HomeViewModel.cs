using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public string WelcomeMessage => "Welcome to Dedsec";

        public ICommand NavigateLoginCommand { get; }

        public HomeViewModel(INavigationService<LoginViewModel> loginNavigationService)
        {
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
        }
    }
}
