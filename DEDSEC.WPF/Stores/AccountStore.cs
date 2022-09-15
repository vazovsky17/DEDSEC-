using DEDSEC.Domain.Models;
using System;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Stores
{
    public class AccountStore
    {
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

        public bool IsLoggedIn => CurrentAccount != null;
        public bool IsAdmin => CurrentAccount?.AccountHolder.IsAdmin ?? false;

        public event Action CurrentAccountChanged;
    }
}
