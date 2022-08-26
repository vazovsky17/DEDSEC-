using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DEDSEC.EntityFramework
{
    public class DedsecDbContextFactory
    {
        private readonly Action<DbContextOptionsBuilder> _configureDbContext;

        public DedsecDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }

        public DedsecDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<DedsecDbContext> options = new DbContextOptionsBuilder<DedsecDbContext>();

            _configureDbContext(options);

            return new DedsecDbContext(options.Options);
        }
    }
}
