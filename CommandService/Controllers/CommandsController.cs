using AutoMapper;
using CommandService.Data;
using CommandService.Dtos;
using CommandService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers;

[Route("api/c/platforms/{platformId}/[controller]")]
[ApiController]
public class CommandsController : ControllerBase
{
    private readonly ICommandRepository _repository;
    private readonly IMapper _mapper;

    public CommandsController(ICommandRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CommandReadDto>> GetAllCommandsForPlatform(int platformId)
    {
        Console.WriteLine($"-->Create commands for platform {platformId}");
        if (!_repository.PlatformExist(platformId))
        {
            return NotFound();
        }
        
        var commands = _repository.GetCommandsForPlatform(platformId);
        if (commands == null)
        {
            return NotFound();
        }
        
        return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
    }

    [HttpGet("{commandId}", Name = nameof(GetCommandForPlatform))]
    public ActionResult<CommandReadDto> GetCommandForPlatform(int platformId, int commandId)
    {
        Console.WriteLine($"-->Get command for platform for platform {platformId}, command {commandId}");
        if (!_repository.PlatformExist(platformId))
        {
            return NotFound();
        }

        var command = _repository.GetCommand(platformId, commandId);
        if (command == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<Command, CommandReadDto>(command));
    }

    [HttpPost]
    public ActionResult<CommandReadDto> CreateCommandForPlatform(int platformId, CommandCreateDto commandCreateDto)
    {
        Console.WriteLine($"-->Create command for platform {platformId}");
        if (!_repository.PlatformExist(platformId))
        {
            return NotFound();
        }

        var command = _mapper.Map<CommandCreateDto, Command>(commandCreateDto);
        _repository.CreateCommand(platformId, command);
        var commandReadDto = _mapper.Map<Command, CommandReadDto>(command);
        return CreatedAtRoute(nameof(GetCommandForPlatform), new { platformId = platformId, commandId = command.Id });
    }
}