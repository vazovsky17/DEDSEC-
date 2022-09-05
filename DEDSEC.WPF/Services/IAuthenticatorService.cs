using DEDSEC.Domain.Models;
using System;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Services
{
    public interface IAuthenticatorService
    {
        Account? CurrentAccount { get; set; }
        bool IsLoggedIn { get; }
        public event Action CurrentAccountChanged;

        Task Register(string nickname, string password, string confirmPassword, bool isAdmin, string? administrationCode);
        Task Login(string nickname, string password, bool isAdmin, string? administrationCode);

        void EditAccount(Account account);
        void Logout();
    }
}
