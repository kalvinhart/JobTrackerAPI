using Domain.Common.ValueObjects;
using Domain.Jobs.Entities;
using Domain.Jobs.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Jobs.Configurations;

public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.ToTable("Jobs");
        
        // Id
        builder.HasKey(j => j.Id);

        builder.Property(j => j.Id)
            .HasConversion(
                id => id.Value,
                value => JobId.From(value))
            .ValueGeneratedNever();

        // Title
        builder.OwnsOne(j => j.Title, t =>
        {
            t.Property(p => p.Value)
                .HasColumnName("Title")
                .HasMaxLength(200)
                .IsRequired();
        });
        builder.Navigation(j => j.Title).IsRequired();

        // Location
        builder.OwnsOne(j => j.Location, l =>
        {
            l.Property(p => p.Value)
                .HasColumnName("Location")
                .HasMaxLength(200)
                .IsRequired();
        });
        builder.Navigation(j => j.Location).IsRequired();

        // Contact Name
        builder.OwnsOne(j => j.ContactName, c =>
        {
            c.Property(p => p.Value)
                .HasColumnName("ContactName")
                .HasMaxLength(200);
        });
        builder.Navigation(j => j.ContactName).IsRequired();

        // SalaryRange → Start + End
        builder.OwnsOne(j => j.Salary, sr =>
        {
            sr.Property(p => p.Start).HasColumnName("SalaryStart");
            sr.Property(p => p.End).HasColumnName("SalaryEnd");
        });
        builder.Navigation(j => j.Salary).IsRequired();
        
        // UserId
        builder.Property(j => j.UserId)
            .HasConversion(
                userId => userId.Value,
                value => UserId.From(value)
            )
            .IsRequired();

        // Navigation: Interviews
        builder.HasMany(j => j.Interviews)
            .WithOne(i => i.Job)
            .HasForeignKey(i => i.JobId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}