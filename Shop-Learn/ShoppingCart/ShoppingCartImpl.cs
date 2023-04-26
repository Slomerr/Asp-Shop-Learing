using Interfaces.ProductCatalog;
using Interfaces.ShoppingCart;

namespace ShoppingCart;

public class ShoppingCartImpl : IShoppingCart
{
    public ShoppingCartImpl(IProductCatalog productCatalog)
    {
        _productCatalog = productCatalog;
    }

    public Cart Get()
    {
        return new Cart
        {
            Orders = _orders
        };
    }

    public Cart AddOrder(Guid productId, int quantity)
    {
        var order = _orders.FirstOrDefault(x => x.Id == productId);
        if (order != null)
        {
            order.Quantity += quantity;
            CreateEvent(CartEventTypeEnum.OrderChanged, order);
        }
        else
        {
            var product = _productCatalog.Get(productId);
            if (product != null)
            {
                order = new Order
                {
                    Id = Guid.NewGuid(),
                    Product = product,
                    Quantity = quantity
                };
                
                _orders.Add(order);
                CreateEvent(CartEventTypeEnum.OrderAdded, order);
            }
        }

        return Get();
    }

    public Cart DeleteOrder(Guid id)
    {
        var order = _orders.FirstOrDefault(x => x.Id == id);
        if (order != null)
        {
            _orders.Remove(order);
            CreateEvent(CartEventTypeEnum.OrderRemoved, order);
        }

        return Get();
    }

    public IEnumerable<CartEvent> GetCartEvents(long timestamp)
    {
        return _events.Where(x => x.Timestamp > timestamp);
    }

    private void CreateEvent(CartEventTypeEnum type, Order order)
    {
        _events.Add( new CartEvent
        {
            Timestamp = DateTime.Now.Ticks,
            Time = DateTime.Now,
            Order = order.Clone(),
            Type = type
        });
    }

    private static List<Order> _orders = new List<Order>();
    private static List<CartEvent> _events = new List<CartEvent>();
    private IProductCatalog _productCatalog;
}