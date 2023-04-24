namespace Interfaces.ProductCatalog;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Product Clone()
    {
        return new Product()
        {
            Id = Id,
            Name = Name
        };
    }
}