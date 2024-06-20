using JobTrackerAPI.DataAccess.Jobs.Repositories;

namespace JobTrackerAPI.DataAccess.Common.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly JobTrackerDbContext _context;

    public IJobsRepository Jobs { get; }

    public UnitOfWork(JobTrackerDbContext context)
    {
        _context = context;
        Jobs = new JobsRepository(context);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}