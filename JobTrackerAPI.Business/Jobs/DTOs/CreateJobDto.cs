using System.ComponentModel.DataAnnotations;

namespace JobTrackerAPI.Business.Jobs.DTOs;

public record CreateJobDto(
    [Required]
    [MaxLength(128)]
    string Title,
    [Required]
    [MaxLength(128)]
    string Location,
    [MaxLength(4000)]
    string? Description,
    [Range(0, 500000)]
    int? SalaryStart,
    [Range(0, 500000)]
    int? SalaryEnd,
    [MaxLength(64)]
    string? ContactName);