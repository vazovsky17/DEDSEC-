using DEDSEC.Domain.Exceptions;
using DEDSEC.Domain.Models;

namespace DEDSEC.Domain.Services.Authentification
{
    public class AuthenticationService : IAuthenticationService
    {
        const string ADMINISTRATION_CODE = "883306";
        private readonly IAccountService _accountService;

        public AuthenticationService(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<Account> Login(string nickname, string password, bool isAdmin, string? administrationCode = null)
        {
            Account storedAccount = await _accountService.GetByNickname(nickname);

            if (storedAccount == null) throw new UserNotFoundException(nickname);

            if (storedAccount.AccountHolder.Password != password) throw new PasswordInvalidException(nickname, password);

            if (storedAccount.AccountHolder.IsAdmin && !isAdmin && string.IsNullOrEmpty(administrationCode)) throw new AdministrationCodeMissingException(isAdmin);
            if (!storedAccount.AccountHolder.IsAdmin && isAdmin) throw new AdministratorRightsMissingException(isAdmin);
            if (isAdmin && (administrationCode == null || administrationCode != ADMINISTRATION_CODE)) throw new AdministrationCodeInvalidException(administrationCode ?? string.Empty);

            return storedAccount;
        }

        public async Task<Account> Register(string nickname, string password, string confirmPassword, bool isAdmin, string? administrationCode = null)
        {
            if (password != confirmPassword) throw new PasswordsDoNotMatchException(password, confirmPassword);

            Account storedAccount = await _accountService.GetByNickname(nickname);
            if (storedAccount != null) throw new NicknameAlreadyExistsException(nickname);

            if (isAdmin && (administrationCode == null || administrationCode != ADMINISTRATION_CODE)) throw new AdministrationCodeInvalidException(administrationCode ?? string.Empty);


            User user = new()
            {
                Id = Guid.NewGuid(),
                Nickname = nickname,
                Password = password,
                IsAdmin = isAdmin,
            };

            Account account = new()
            {
                Id = Guid.NewGuid(),
                AccountHolder = user,
                Name = String.Empty,
                Age = 0,
                AboutMe = String.Empty,
                IsVisited = false,
                FavoriteGames = new List<Game>()
            };

            await _accountService.Create(account);

            return account;
        }
    }
}
