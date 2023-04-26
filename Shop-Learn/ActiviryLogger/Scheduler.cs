using Interfaces.ActivityLogger;

namespace ActiviryLogger;

public class Scheduler : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Timer timer = new Timer(new TimerCallback(PollEvents), stoppingToken, 2000, 2000);
        return Task.CompletedTask;
    }

    private void PollEvents(object state)
    {
        try
        {
            var logger = _serviceProvider.GetService(typeof(IActivityLogger)) as ActivityLoggerImpl;
            logger.ReceiveEvents();
        }
        catch
        {
            
        }
    }

    private IServiceProvider _serviceProvider;
}