using Services_Repos.Data;
using Services_Repos.Models.Data_Classes;

namespace Services_Repos.Models.Repositories;

public class ProductRepository(AppDbContext dbContext) : IRepository<Product>
{
    private readonly AppDbContext _dbContext = dbContext;
    //private List<Product> _products = [];
    public void Add(Product item)
    {
        _dbContext.Products.Add(item);
        _dbContext.SaveChanges();
    }

    public List<Product> GetAll() => [.. _dbContext.Products];

    public Product GetById(int id) => _dbContext.Products.Find(id);

    public void Remove(Product item)
    {
        _dbContext.Remove(item);
        _dbContext.SaveChanges();
    }

    public void Update(Product item)
    {
        _dbContext.Update(item);
        _dbContext.SaveChanges();
    }
}

