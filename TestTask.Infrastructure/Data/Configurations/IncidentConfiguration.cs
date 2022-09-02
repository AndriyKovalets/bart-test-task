using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Domain.Entities;

namespace TestTask.Infrastructure.Data.Configurations
{
    internal class IncidentConfiguration : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder
                .HasKey(x => x.Name);

            builder
                .Property(x => x.Name)
                .HasDefaultValueSql("NEWID()");

            builder
                .Property(x => x.Description)
                .HasMaxLength(1000)
                .IsRequired();

            builder
                .Property(x => x.AccountId)
                .IsRequired();

            builder
                .HasOne(x => x.Account)
                .WithMany(x => x.Incidents)
                .HasForeignKey(x => x.AccountId);
        }
    }
}
