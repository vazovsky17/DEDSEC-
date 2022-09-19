using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DEDSEC.EntityFramework
{
    public class DedsecContextFactory : IDesignTimeDbContextFactory<DedsecDbContext>
    {
        public DedsecDbContext CreateDbContext(string[] args)
        {
            string conStr = "Server = (localdb)\\MSSQLLocalDB; Database = Dedsec; Trusted_Connection = True";
            var optionsBuilder = new DbContextOptionsBuilder<DedsecDbContext>();
            optionsBuilder.UseSqlServer(conStr);

            return new DedsecDbContext(optionsBuilder.Options);
        }
    }
}
