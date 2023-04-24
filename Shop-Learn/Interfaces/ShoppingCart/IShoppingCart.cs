using Shed.CoreKit.WebApi;

namespace Interfaces.ShoppingCart;

public interface IShoppingCart
{
    Cart Get();

    [HttpPut, Route("addorder/{productId}/{quantity}")]
    void AddOrder(Guid productId, int quantity);

    Cart DeleteOrder(Guid id);

    [Route("getevents/{timestamp}")]
    IEnumerable<CartEvent> GetCartEvents(int timestamp);
}