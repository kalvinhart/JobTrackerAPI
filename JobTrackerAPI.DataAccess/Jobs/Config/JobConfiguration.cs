using JobTrackerAPI.DataAccess.Jobs.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobTrackerAPI.DataAccess.Jobs.Config;

public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(128);
        builder.Property(e => e.Location)
            .IsRequired()
            .HasMaxLength(128);
        builder.Property(e => e.ContactName)
            .HasMaxLength(64);
        builder.Property(e => e.Description)
            .HasMaxLength(4000);
        builder.Property(e => e.Status)
            .IsRequired();

        builder.HasMany(e => e.Interviews)
            .WithOne(e => e.Job);
    }
}