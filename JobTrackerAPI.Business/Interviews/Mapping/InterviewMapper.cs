using JobTrackerAPI.Business.Interviews.DTOs;
using JobTrackerAPI.DataAccess.Interviews.Entities;

namespace JobTrackerAPI.Business.Interviews.Mapping;

public static class InterviewMapper
{
    public static InterviewDto MapToDto(this Interview interview)
    {
        return new InterviewDto(
            Id: interview.Id,
            JobId: interview.JobId,
            Date: interview.Date,
            Notes: interview.Notes
        );
    }
}