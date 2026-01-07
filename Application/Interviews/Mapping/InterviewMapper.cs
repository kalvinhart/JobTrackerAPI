using Application.Interviews.DTOs;
using Domain.Interviews.Entities;

namespace Application.Interviews.Mapping;

public static class InterviewMapper
{
    public static InterviewDto MapToDto(this Interview interview)
    {
        return new InterviewDto(
            Id: interview.Id.Value,
            JobId: interview.JobId.Value,
            Date: interview.Date.Value,
            Notes: interview.Notes
        );
    }
}