using DEDSEC.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DEDSEC.EntityFramework
{
    public class DedsecDbContext : DbContext
    {
        public DedsecDbContext(DbContextOptions options) : base(options) {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<User> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Dedsec;Trusted_Connection=True;");
        //}
    }
}
