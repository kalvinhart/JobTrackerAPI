namespace Application.Interviews.DTOs;

public record InterviewDto(
    Guid Id,
    DateTime Date,
    Guid JobId,
    string? Notes);