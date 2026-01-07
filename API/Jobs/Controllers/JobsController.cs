using API.Extensions;
using Application.Jobs.Commands.CreateJob;
using Application.Jobs.DTOs;
using Application.Jobs.Queries.GetAllJobs;
using Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Jobs.Controllers;

[Authorize]
[ApiController]
[Route("jobs")]
public class JobsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly UserManager<User> _userManager;

    public JobsController(
        ISender sender,
        UserManager<User> userManager)
    {
        _sender = sender;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllJobs()
    {
        var query = new GetAllJobsQuery();
        var jobs = await _sender.Send(query);

        return Ok(jobs);
    }

    [HttpPost]
    public async Task<IActionResult> CreateJob(CreateJobDto createJobDto)
    {
        var userId = _userManager.GetUserId(User)!.ToGuid();
        var command = new CreateJobCommand(createJobDto, userId);
        var result = await _sender.Send(command);

        return CreatedAtAction(
            nameof(CreateJob),
            new { id = result.Id },
            result);
    }
}