using System.ComponentModel.DataAnnotations;

namespace Application.Jobs.DTOs;

public record CreateJobDto(
    [Required]
    [MaxLength(128)]
    string Title,
    [Required]
    [MaxLength(128)]
    string Location,
    [MaxLength(4000)]
    string? Description,
    [Required]
    [Range(0, 500000)]
    int SalaryStart,
    [Required]
    [Range(0, 500000)]
    int SalaryEnd,
    [MaxLength(64)]
    string? ContactName);