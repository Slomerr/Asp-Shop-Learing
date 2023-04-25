using Shed.CoreKit.WebApi;

namespace Interfaces.ProductCatalog;

public interface IProductCatalog
{
    IEnumerable<Product> Get();

    [Route("get/{productId}")]
    Product Get(Guid productId);
}