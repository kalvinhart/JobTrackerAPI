using JobTrackerAPI.Business.Jobs.Queries.GetAllJobs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobTrackerAPI.Jobs.Controllers;

[ApiController]
[Route("jobs")]
public class JobsController : ControllerBase
{
    private readonly ISender _sender;

    public JobsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllJobs()
    {
        var query = new GetAllJobsQuery();
        var jobs = await _sender.Send(query);

        return Ok(jobs);
    }
}