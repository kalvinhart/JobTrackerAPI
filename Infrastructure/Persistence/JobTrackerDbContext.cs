using Domain.Interviews.Entities;
using Domain.Jobs.Entities;
using Infrastructure.Identity;
using Infrastructure.Persistence.Interviews.Configurations;
using Infrastructure.Persistence.Jobs.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class JobTrackerDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public JobTrackerDbContext(DbContextOptions<JobTrackerDbContext> options) : base(options)
    {
    }

    public DbSet<Job> Jobs { get; set; }
    public DbSet<Interview> Interviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new JobConfiguration());
        modelBuilder.ApplyConfiguration(new InterviewConfiguration());
    }
}