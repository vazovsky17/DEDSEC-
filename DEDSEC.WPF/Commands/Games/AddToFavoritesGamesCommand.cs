using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services.Authentification;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Services;
using System.Threading.Tasks;
using System.Windows;

namespace DEDSEC.WPF.Commands.Games
{
    public class AddToFavoritesGamesCommand : AsyncCommandBase
    {
        private readonly Game _game;
        private readonly IAccountService _dataService;
        private readonly IAuthenticatorService _authenticatorService;

        public AddToFavoritesGamesCommand(Game game,
            IAccountService dataService,
            IAuthenticatorService authenticatorService)
        {
            _game = game;
            _dataService = dataService;
            _authenticatorService = authenticatorService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var account = _authenticatorService.CurrentAccount;
            if (account != null)
            {
                account.FavoriteGames.Add(_game);
                await _dataService.Update(account.Id, account).ContinueWith(task =>
                {
                    if (task.IsCompleted)
                    {
                        MessageBox.Show(account.FavoriteGames.Count.ToString());
                        _authenticatorService.EditAccount(account);
                    }
                });
            }
        }
    }
}
