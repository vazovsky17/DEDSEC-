using DEDSEC.Domain.Models;

namespace DEDSEC.Domain.Services.Authentification
{
    /// <summary>
    /// Расширенный сервис для операций с аккаунтами
    /// </summary>
    public interface IAccountDataService : IDataService<Account>
    {
        /// <summary>
        /// Поиск аккаунта по никнейму
        /// </summary>
        /// <param name="nickname">Никнейм</param>
        /// <returns>Аккаунт, если есть</returns>
        Task<Account> GetByNickname(string nickname);
    }
}
