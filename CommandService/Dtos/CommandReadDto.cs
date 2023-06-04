using System.Diagnostics.CodeAnalysis;

namespace CommandService.Dtos;

public class CommandReadDto
{
    public int Id { get; set; }
    [MaybeNull]
    public string HowTo { get; set; }
    [MaybeNull]
    public string CommandLine { get; set; }
    public int PlatformId { get; set; }
}