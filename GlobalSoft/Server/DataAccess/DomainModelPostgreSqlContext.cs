
using GlobalSoft.Shared;
using Microsoft.EntityFrameworkCore;

namespace GlobalSoft.Server.DataAccess
{
    public class DomainModelPostgreSqlContext : DbContext
    {
        public DomainModelPostgreSqlContext(DbContextOptions<DomainModelPostgreSqlContext> options) : base(options)
        {
        }

        public DbSet<UserInfo> UserInfos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("User ID=postgres;Password=trip0321!;Host=trip-pgdb.cfqxolbra9en.ap-northeast-2.rds.amazonaws.com;Port=5432;Database=postgres;");
            }
        }
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
