using Application.Interviews.DTOs;
using Domain.Jobs.Enums;

namespace Application.Jobs.DTOs;

public record JobDto(
    Guid Id,
    string Title,
    string Location,
    ApplicationStatus Status,
    Guid UserId,
    string? Description,
    int SalaryStart,
    int SalaryEnd,
    string? ContactName,
    List<InterviewDto> Interviews);