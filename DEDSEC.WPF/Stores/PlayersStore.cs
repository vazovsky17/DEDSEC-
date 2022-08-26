using DEDSEC.Domain.Models;
using System;

namespace DEDSEC.WPF.Stores
{
    public class PlayersStore
    {
        public event Action<Account> PlayerAdded;

        public void AddPlayer(Account account)
        {
            PlayerAdded?.Invoke(account);
        }
    }
}
