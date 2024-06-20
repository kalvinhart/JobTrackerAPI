using Microsoft.EntityFrameworkCore.Query;

namespace JobTrackerAPI.DataAccess.Common.DTOs;

public class ContextGetParameters<T> where T : class
{
    public Func<IQueryable<T>, IIncludableQueryable<T, object>>? Includes { get; set; } = null;
    public bool DisableTracking { get; set; } = false;
}