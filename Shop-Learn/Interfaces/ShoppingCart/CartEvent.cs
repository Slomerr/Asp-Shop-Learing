namespace Interfaces.ShoppingCart;

public class CartEvent : EventBase
{
    public CartEventTypeEnum Type { get; set; }
    public Order Order { get; set; }
}