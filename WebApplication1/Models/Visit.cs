using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Visit
{
    [Required]
    public required DateTime VisitDate { get; set; }
    [Required]
    public required int AnimalId { get; set; }
    [Required]
    [MaxLength(200)]
    public required string Description { get; set; }
    [Required]
    public required decimal Price { get; set; }
}
