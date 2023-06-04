using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CommandService.Models;

public class Platform
{
    [Key]
    [Required]
    public int Id {get; set; }

    [Required]
    public int ExternalId { get; set; }

    [MaybeNull]
    [Required]
    public string Name { get; set; }

    public ICollection<Command> Commands { get; set; } = new List<Command>();
}