using Services_Repos.Data;
using Services_Repos.Models.Data_Classes;

namespace Services_Repos.Models.Repositories;

public class ProductRepository(AppDbContext dbContext) : IRepository<Product>
{
    private readonly AppDbContext _dbContext = dbContext;
    private List<Product> _products = [];
    public void Add(Product item) => _dbContext.Add(item);

    public List<Product> GetAll() => [.. _dbContext.Products];

    public Product GetById(int id) => _dbContext.Find<Product>(id);

    public void Remove(Product item) => _dbContext.Remove(item);

    public void Update(Product item)
    {
        _dbContext.Update(item);
        //Product? product = _products.Find(p => p.Id == item.Id);
        //if (product != null)
        //{
        //    product.Id = item.Id;
        //    product.Name = item.Name;
        //    product.Description = item.Description;
        //    product.Price = item.Price;
        //}
    }
}

