using DEDSEC.Domain.Models;

namespace DEDSEC.Domain.Services.Authentification
{
    public interface IAccountService : IDataService<Account>
    {
        Task<Account> GetByNickname(string nickname);
    }
}
