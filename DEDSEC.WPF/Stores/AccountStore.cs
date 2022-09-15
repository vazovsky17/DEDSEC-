﻿using DEDSEC.Domain.Models;
using System;

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
        public bool IsAdmin => CurrentAccount?.AccountHolder.IsAdmin ?? false;

        public void EditAccount(Account account)
        {
            CurrentAccount = account;
            CurrentAccountChanged?.Invoke();
        }
        public event Action CurrentAccountChanged;
    }
}
