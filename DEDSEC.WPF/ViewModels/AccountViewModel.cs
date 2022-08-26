using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;

        public string Nickname => _accountStore.CurrentAccount?.AccountHolder.Nickname ?? "Unknown";
        public string Name => _accountStore.CurrentAccount?.Name ?? "Unknown";
        public int Age => _accountStore.CurrentAccount?.Age ?? 0;
        public string AboutAge => _accountStore.CurrentAccount?.AboutMe ?? "About me...";
        public bool IsVisited => _accountStore.CurrentAccount?.IsVisited ?? true;

        public ICommand NavigateHomeCommand { get; }

        public AccountViewModel(AccountStore accountStore, INavigationService homeNavigationService)
        {
            _accountStore = accountStore;
            NavigateHomeCommand = new NavigateCommand(homeNavigationService);

            _accountStore.CurrentAccountChanged += OnCurrentAccountChanged;
        }

        private void OnCurrentAccountChanged()
        {
            OnPropertyChanged(nameof(Nickname));
        }

        public override void Dispose()
        {
            _accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;

            base.Dispose();

        }
    }
}
