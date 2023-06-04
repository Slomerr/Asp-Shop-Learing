using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace  CommandService.Dtos;

public class CommandCreateDto 
{
    [MaybeNull]
    [Required]
    public string HowTo { get; set; }
    [MaybeNull]
    [Required]
    public string CommandLine { get; set; }
}