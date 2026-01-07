using Domain.Interviews.Entities;
using Domain.Interviews.ValueObjects;
using Domain.Jobs.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Interviews.Configurations;

public class InterviewConfiguration : IEntityTypeConfiguration<Interview>
{
    public void Configure(EntityTypeBuilder<Interview> builder)
    {
        builder.ToTable("Interviews");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .HasConversion(
                id => id.Value,
                value => InterviewId.From(value)
            )
            .ValueGeneratedNever();
        
        builder.OwnsOne(i => i.Date, d =>
        {
            d.Property(p => p.Value)
                .HasColumnName("InterviewDate")
                .IsRequired();
        });

        builder.Property(i => i.JobId)
            .HasConversion(
                id => id.Value,
                value => JobId.From(value)
            );
    }
}