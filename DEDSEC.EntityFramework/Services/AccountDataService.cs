using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services.Authentification;
using Microsoft.EntityFrameworkCore;

namespace DEDSEC.EntityFramework.Services
{
    /// <summary>
    /// Сервис для операций с аккаунтом
    /// </summary>
    public class AccountDataService : IAccountService
    {
        private readonly DedsecDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Account> _nonQueryDataService;

        public AccountDataService(DedsecDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new (contextFactory);
        }

        public async Task<Account> Create(Account entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<Account> Get(Guid id)
        {
            using (DedsecDbContext context = _contextFactory.CreateDbContext())
            {
                Account entity = await context.Accounts
                    .Include(a => a.AccountHolder)
                    .Include(a => a.FavoriteGames)
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using (DedsecDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Account> entities = await context.Accounts
                    .Include(a => a.AccountHolder)
                    .Include(a => a.FavoriteGames)
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<Account> GetByNickname(string nickname)
        {
            using (DedsecDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Accounts
                    .Include(a => a.AccountHolder)
                    .Include(a => a.FavoriteGames)
                    .FirstOrDefaultAsync(a => a.AccountHolder.Nickname == nickname);
            }
        }

        public async Task<Account> Update(Guid id, Account entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
