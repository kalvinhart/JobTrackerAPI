using JobTrackerAPI.DataAccess.Interviews.Config;
using JobTrackerAPI.DataAccess.Interviews.Entities;
using JobTrackerAPI.DataAccess.Jobs.Config;
using JobTrackerAPI.DataAccess.Jobs.Entities;
using JobTrackerAPI.DataAccess.Users.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerAPI.DataAccess;

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