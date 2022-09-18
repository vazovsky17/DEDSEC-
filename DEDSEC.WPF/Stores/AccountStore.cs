using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services.Authentification;
using System;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Stores
{
    public class AccountStore
    {
        private readonly IAccountService _accountService;

        private Account _currentAccount;
        public Account CurrentAccount
        {
            get => _currentAccount;
            set
            {
                _currentAccount = value;
                CurrentAccountChanged?.Invoke();
            }
        }
        public bool IsAdmin => CurrentAccount?.AccountHolder.IsAdmin ?? false;

        public void EditAccount(Account account)
        {
            CurrentAccount = account;
            CurrentAccountChanged?.Invoke();
        }
        public event Action CurrentAccountChanged;

        public AccountStore(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task AddToFavoriteGames(Game game)
        {
            _currentAccount.FavoriteGames.Add(game);
            await _accountService.Update(_currentAccount.Id, _currentAccount).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    EditAccount(_currentAccount);
                }
            });
        }

        public async Task EditFavoriteGame(Game game)
        {
            var storedGame = _currentAccount.FavoriteGames.Find(item => item.Id == game.Id);
            if(storedGame != null)
            {
                await DeleteFromFavoriteGames(storedGame);
                await AddToFavoriteGames(game);
            }
        }

        public async Task DeleteFromFavoriteGames(Game game)
        {
            var storedGame = _currentAccount.FavoriteGames.Find(item => item.Id == game.Id);
            if (storedGame != null)
            {
                _currentAccount.FavoriteGames.Remove(storedGame);
                await _accountService.Update(_currentAccount.Id, _currentAccount).ContinueWith(task =>
                {
                    if (task.IsCompleted)
                    {
                        EditAccount(_currentAccount);
                    }
                });
            }
        }
    }
}
