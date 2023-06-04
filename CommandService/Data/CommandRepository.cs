using CommandService.Models;

namespace CommandService.Data;

public class CommandRepository : ICommandRepository
{
    private AppDbContext _context;

    public CommandRepository(AppDbContext context)
    {
        _context = context;
    }

    public void CreateCommand(int platformId, Command command)
    {
        if (command == null)
        {
            throw new ArgumentNullException(nameof(Command));
        }

        command.PlatformId = platformId;
        _context.Commands.Add(command);
    }

    public void CreatePlatform(Platform platform)
    {
        if (platform == null)
        {
            throw new ArgumentNullException(nameof(Platform));
        }

        _context.Platforms.Add(platform);
    }

    public IEnumerable<Platform> GetAllPlatforms()
    {
        return _context.Platforms.ToList();
    }

    public Command GetCommand(int platformId, int commandId)
    {
        return _context.Commands
            .Where(x => x.PlatformId == platformId && x.Id == commandId)
            .FirstOrDefault();
    }

    public IEnumerable<Command> GetCommandsForPlatform(int platformId)
    {
        return _context.Commands
            .Where(x => x.PlatformId == platformId)
            .OrderBy(x => x.Platform.Name);
    }

    public bool PlatformExist(int platformId)
    {
        return _context.Platforms.Any(x => x.Id == platformId);
    }

    public bool SaveChanges()
    {
        return _context.SaveChanges() >= 0;
    }
}