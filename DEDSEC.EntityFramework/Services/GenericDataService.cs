using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DEDSEC.EntityFramework.Services
{
    /// <summary>
    /// Сервис для общих операций с объектами
    /// </summary>
    /// <typeparam name="T">Тип объектов</typeparam>
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        /** Можно было бы создать просто контекст, но лучше фабрику, чтобы куча потоков не использовала один контекст */
        private readonly DedsecDbContextFactory _contextFactory;

        public GenericDataService(DedsecDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using (DedsecDbContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return createdResult.Entity;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            using (DedsecDbContext context = _contextFactory.CreateDbContext())
            {
                T enity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(enity);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<T> Get(Guid id)
        {
            using (DedsecDbContext context = _contextFactory.CreateDbContext())
            {
                T enity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                return enity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (DedsecDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> enities = await context.Set<T>().ToListAsync();
                return enities;
            }
        }

        public async Task<T> Update(Guid id, T entity)
        {
            using (DedsecDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }
    }
}
