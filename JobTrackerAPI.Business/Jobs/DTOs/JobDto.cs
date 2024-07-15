using JobTrackerAPI.Business.Interviews.DTOs;
using JobTrackerAPI.DataAccess.Jobs.Enums;

namespace JobTrackerAPI.Business.Jobs.DTOs;

public record JobDto(
    Guid Id,
    string Title,
    string Location,
    ApplicationStatus Status,
    Guid UserId,
    string? Description,
    int? SalaryStart,
    int? SalaryEnd,
    string? ContactName,
    List<InterviewDto> Interviews);