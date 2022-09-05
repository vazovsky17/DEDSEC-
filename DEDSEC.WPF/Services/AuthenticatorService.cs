using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services.Authentification;
using DEDSEC.WPF.Stores;
using System;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Services
{
    public class AuthenticatorService : IAuthenticatorService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly AccountStore _accountStore;

        public AuthenticatorService(IAuthenticationService authenticationService, AccountStore accountStore)
        {
            _authenticationService = authenticationService;
            _accountStore = accountStore;
        }

        public Account CurrentAccount
        {
            get { return _accountStore.CurrentAccount; }
            set
            {
                _accountStore.CurrentAccount = value;
                CurrentAccountChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => CurrentAccount != null;

        public event Action CurrentAccountChanged;

        public async Task Login(string nickname, string password, bool isAdmin, string? administrationCode)
        {
            CurrentAccount = await _authenticationService.Login(nickname, password, isAdmin, administrationCode);
        }

        public async Task Register(string nickname, string password, string confirmPassword, bool isAdmin, string? administrationCode)
        {
            CurrentAccount = await _authenticationService.Register(nickname, password, confirmPassword, isAdmin, administrationCode);
        }

        public void EditAccount(Account account)
        {
            CurrentAccount = account;
        }

        public void Logout()
        {
            CurrentAccount = null;
        }

    }
}
