using Shed.CoreKit.WebApi;

namespace Interfaces.ProductCatalog;

public interface IProductCatalog
{
    IEnumerator<Product> Get();

    [Route("get/{productId}")]
    Product Get(Guid productId);
}