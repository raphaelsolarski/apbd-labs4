using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Animal
{
    public int? IdAnimal { get; set; }
    [Required]
    [MaxLength(200)]
    public required string Name { get; set; }
    [Required]
    public required double Wage { get; set; }
    [Required]
    [MaxLength(200)]
    public required string Color { get; set; }
}
