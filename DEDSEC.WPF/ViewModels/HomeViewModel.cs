using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public string WelcomeMessage => "Welcome to Dedsec";
        public NavigationBarViewModel NavigationBarViewModel { get; }

        public ICommand NavigateLoginCommand { get; }

        public HomeViewModel(NavigationBarViewModel navigationBarViewModel, NavigationService<LoginViewModel> loginNavigationService)
        {
            NavigationBarViewModel = navigationBarViewModel;
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
        }
    }
}
