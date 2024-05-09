namespace _3xamen2Rene.DB;


public record Product
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public string? description { get; set; }
}

public class ProductDB
{
    private static List<Product> _products = new List<Product>()
   {
     new Product{ Id=1, Name="Sobresito de Cocaina",description="Polvo magico para ir a las nubes" },
     new Product{ Id=2, Name="Galleta Oreo",description="Galleta de chocolate"},
     new Product{ Id=3, Name="Sopa Maruchan",description="Sopon para matar el hambre maruchan"}
   };

    public static List<Product> GetProducts()
    {
        return _products;
    }

    public static Product? GetProduct(int id)
    {
        return _products.SingleOrDefault(product => product.Id == id);
    }

    public static Product CreateProduct(Product product)
    {
        _products.Add(product);
        return product;
    }

    public static Product UpdateProduct(Product update)
    {
        _products = _products.Select(product =>
        {
            if (product.Id == update.Id)
            {
                product.Name = update.Name;
                product.description = update.description;
            }
            return product;
        }).ToList();
        return update;
    }

    public static void RemoveProduct(int id)
    {
        _products = _products.FindAll(product => product.Id != id).ToList();
    }
}
