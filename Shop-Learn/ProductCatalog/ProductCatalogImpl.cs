using Interfaces.ProductCatalog;

namespace ProductCatalog;

public class ProductCatalogImpl : IProductCatalog
{
    public IEnumerable<Product> Get()
    {
        return _products;
    }

    public Product Get(Guid productId)
    {
        return _products.FirstOrDefault(x => x.Id == productId);
    }

    private Product[] _products = new Product[]
    {
        new Product() { Id = new Guid("38E66039-458B-4CAF-A36F-7056EA721069"), Name = "T-shirt" },
        new Product() { Id = new Guid("BD00D5DC-F05B-4B8A-AE52-2D072BFB1B89"), Name = "Hoodie" },
        new Product() { Id = new Guid("07AF6245-55BC-4A51-8EA0-143A9EF99EE8"), Name = "Trousers" }
    };
}