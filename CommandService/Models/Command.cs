using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CommandService.Models;

public class Command
{
    [Key]
    [Required]
    public int Id { get; set; }
    
    [MaybeNull]
    [Required]
    public string HowTo { get; set; }
    
    [MaybeNull]
    [Required]
    public string CommandLine { get; set; }
    
    [Required]
    public int PlatformId { get; set; }

    [MaybeNull]
    public Platform Platform { get; set; }
}