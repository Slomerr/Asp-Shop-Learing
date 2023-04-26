namespace Interfaces.ShoppingCart;

public class Cart
{
    public IEnumerable<Order> Orders { get; set; }
}