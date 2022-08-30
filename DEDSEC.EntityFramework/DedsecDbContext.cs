using DEDSEC.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DEDSEC.EntityFramework
{
    public class DedsecDbContext : DbContext
    {
        public DedsecDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<DonationGoal> DonationGoals { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
