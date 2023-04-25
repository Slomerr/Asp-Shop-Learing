namespace Interfaces.ActivityLogger;

public interface IActivityLogger
{
    IEnumerable<LogEvent> Get(long timestamp);
}