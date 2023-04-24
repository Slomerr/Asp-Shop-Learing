using Interfaces.ProductCatalog;

namespace Interfaces.ShoppingCart;

public class Order
{
    public Guid Id { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }

    public Order Clone()
    {
        return new Order()
        {
            Id = Id,
            Product = Product,
            Quantity = Quantity
        };
    }
}