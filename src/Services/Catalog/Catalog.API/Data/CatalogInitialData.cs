using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync())
        {
            return;
        }

        session.Store<Product>(GetPreConfiguredProducts());
        await session.SaveChangesAsync();
    }

    private static IEnumerable<Product> GetPreConfiguredProducts() => new List<Product>()
    {
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "IPhone X",
                Description = "Description for Product 1",
                ImageFile = "product-1.png",
                Price = 950.00M,
                Category = new List<string> { "Smart Phone", "Electronics" }
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Samsung 10",
                Description = "Description for Product 2",
                ImageFile = "product-2.png",
                Price = 200.00M,
                Category = new List<string> { "Smart Phone", "Electronics" }
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Huawei Plus",
                Description = "Description for Product 3",
                ImageFile   = "product-3.png",
                Price = 500.00M,
                Category = new List<string> { "Smart Phone", "Electronics" }
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Xiaomi Mi 9",
                Description = "Description for Product 4",
                ImageFile = "product-4.png",
                Price = 300.00M,
                Category = new List<string> { "Home Kitchen", "Electronics" }
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Sony Play Station",
                Description = "Description for Product 5",
                ImageFile = "product-5.png",
                Price = 200.00M,
                Category = new List<string> { "Camera", "Electronics" }
            },
    };
}
