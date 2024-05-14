using EntityFrameworkCodeFirstApproach.Model;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCodeFirstApproach.EntityDbContext
{
    public class MasterDbContext:DbContext
    {
        public MasterDbContext(DbContextOptions<MasterDbContext> dbContextOptions):base(dbContextOptions) { }
        

        public DbSet<Company> Company { get; set; }
        public DbSet<Country> Country { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Company>().ToTable(nameof(Company));
            modelBuilder.Entity<Country>().ToTable(nameof(Country),"dbo");

            modelBuilder.Entity<Company>().Property(x => x.Name)
                .HasColumnName("CompanyName")
                .HasColumnType("nvarchar(30)")
                .HasDefaultValue("A");
        }
    }
}
