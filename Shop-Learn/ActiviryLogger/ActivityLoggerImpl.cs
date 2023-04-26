using Interfaces.ActivityLogger;
using Interfaces.ShoppingCart;

namespace ActiviryLogger;

public class ActivityLoggerImpl : IActivityLogger
{
    public ActivityLoggerImpl(IShoppingCart shoppingCart)
    {
        _shoppingCart = shoppingCart;
    }
    
    public IEnumerable<LogEvent> Get(long timestamp)
    {
        return _logs.Where(x => x.Timestamp > timestamp);
    }

    public void ReceiveEvents()
    {
        var cartEvents = _shoppingCart.GetCartEvents(_timestamp);
        if (cartEvents.Any())
        {
            _timestamp = cartEvents.Max(x => x.Timestamp);
            _logs.AddRange(cartEvents.Select(x => new LogEvent()
            {
                Description = $"{x.Type}: '{x.Order.Product.Name} ({x.Order.Quantity})'"
            }));
        }
    }

    private IShoppingCart _shoppingCart;
    private static long _timestamp;
    private static List<LogEvent> _logs = new List<LogEvent>();
}