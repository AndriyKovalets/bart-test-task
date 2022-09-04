using Microsoft.EntityFrameworkCore;
using TestTask.Domain.Entities;
using TestTask.Infrastructure.Data.Configurations;

namespace TestTask.Infrastructure.Data
{
    public class TestTaskDbContext : DbContext
    {
        public TestTaskDbContext(DbContextOptions<TestTaskDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new IncidentConfiguration());
        }

        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<Account>? Accounts { get; set; }
        public DbSet<Incident>? Incidents { get; set; }
    }
}
