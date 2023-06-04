using System.Diagnostics.CodeAnalysis;

namespace CommandService.Dtos;

public class PlatformReadDto
{
    public int Id { get; set; }
    [MaybeNull]
    public string Name { get; set; }
}