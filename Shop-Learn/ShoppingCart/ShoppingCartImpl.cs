using Interfaces.ShoppingCart;

namespace ShoppingCart;

public class ShoppingCartImpl : IShoppingCart
{
    public Cart Get()
    {
        throw new NotImplementedException();
    }

    public void AddOrder(Guid productId, int quantity)
    {
        throw new NotImplementedException();
    }

    public Cart DeleteOrder(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<CartEvent> GetCartEvents(int timestamp)
    {
        throw new NotImplementedException();
    }
}