using DEDSEC.Domain.Models;
using DEDSEC.WPF.Extensions;
using DEDSEC.WPF.Stores;
using System.Collections.Generic;

namespace DEDSEC.WPF.ViewModels.Accounts
{
    public class AccountViewModel : ViewModelBase
    {
        public AccountStore AccountStore { get; }

        public Account CurrentAccount => AccountStore.CurrentAccount;
        
        #region Bindings
        public string Nickname => CurrentAccount.SetNicknameDisplay();
        public string Name => CurrentAccount.SetNameDisplay();
        public string Age => CurrentAccount.SetAgeDisplay();
        public string AboutMe => CurrentAccount.SetAboutMeDisplay();
        public bool IsVisited => CurrentAccount?.IsVisited ?? false;
        public List<Game> FavoriteGames => CurrentAccount?.FavoriteGames ?? new();
        public bool HasFavoriteGames => FavoriteGames.Count > 0;
        #endregion

        public AccountViewModel(AccountStore accountStore)
        {
            AccountStore = accountStore;

            AccountStore.CurrentAccountChanged += OnCurrentAccountChanged;
        }

        public void OnCurrentAccountChanged()
        {
            OnPropertyChanged(nameof(CurrentAccount));
            OnPropertyChanged(nameof(Nickname));
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Age));
            OnPropertyChanged(nameof(AboutMe));
            OnPropertyChanged(nameof(IsVisited));
            OnPropertyChanged(nameof(AboutMe));
            OnPropertyChanged(nameof(FavoriteGames));
            OnPropertyChanged(nameof(HasFavoriteGames));
        }

        public override void Dispose()
        {
            AccountStore.CurrentAccountChanged -= OnCurrentAccountChanged;

            base.Dispose();
        }
    }
}
