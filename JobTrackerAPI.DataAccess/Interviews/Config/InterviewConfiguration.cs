using JobTrackerAPI.DataAccess.Interviews.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobTrackerAPI.DataAccess.Interviews.Config;

public class InterviewConfiguration : IEntityTypeConfiguration<Interview>
{
    public void Configure(EntityTypeBuilder<Interview> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Notes)
            .HasMaxLength(2000);

        builder.HasOne(e => e.Job)
            .WithMany(e => e.Interviews)
            .HasForeignKey(e => e.Id);
    }
}