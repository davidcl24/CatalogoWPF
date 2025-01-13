using Services_Repos.Models.Data_Classes;

namespace Services_Repos.Models.Repositories;

public class ProductRepository : IRepository<Product>
{
    private List<Product> _products = [];
    public void Add(Product item) => _products.Add(item);

    public List<Product> GetAll() => _products;

    public Product GetById(int id) => _products.Find(p => p.Id == id);

    public void Remove(Product item) => _products.Remove(item);

    public void Update(Product item)
    {
        Product? product = _products.Find(p => p.Id == item.Id);
        if (product != null)
        {
            product.Id = item.Id;
            product.Name = item.Name;
            product.Description = item.Description;
            product.Price = item.Price;
        }
    }
}

