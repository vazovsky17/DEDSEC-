using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services.Authentification;
using System;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Stores
{
    public class AccountStore
    {
        private readonly IAccountDataService _accountService;
        public bool IsAdmin => CurrentAccount?.AccountHolder.IsAdmin ?? false;

        #region Properties
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
        #endregion  

        public event Action CurrentAccountChanged;

        public void EditAccount(Account account)
        {
            CurrentAccount = account;
            CurrentAccountChanged?.Invoke();
        }

        public AccountStore(IAccountDataService accountService)
        {
            _accountService = accountService;
        }
        #region Favorite Games
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
            if (storedGame != null)
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
        #endregion

        #region Feature Meetings
        public async Task AddToFeatureMeetings(Meeting meeting)
        {
            _currentAccount.FeatureMeetings.Add(meeting);
            await _accountService.Update(_currentAccount.Id, _currentAccount).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    EditAccount(_currentAccount);
                }
            });
        }

        public async Task EditFeatureMeeting(Meeting meeting)
        {
            var storedMeeting = _currentAccount.FeatureMeetings.Find(item => item.Id == meeting.Id);
            if (storedMeeting != null)
            {
                await DeleteFromFeatureMeetings(storedMeeting);
                await AddToFeatureMeetings(meeting);
            }
        }

        public async Task DeleteFromFeatureMeetings(Meeting meeting)
        {
            var storedMeeting = _currentAccount.FeatureMeetings.Find(item => item.Id == meeting.Id);
            if (storedMeeting != null)
            {
                _currentAccount.FeatureMeetings.Remove(storedMeeting);
                await _accountService.Update(_currentAccount.Id, _currentAccount).ContinueWith(task =>
                {
                    if (task.IsCompleted)
                    {
                        EditAccount(_currentAccount);
                    }
                });
            }
        }
        #endregion
    }
}
