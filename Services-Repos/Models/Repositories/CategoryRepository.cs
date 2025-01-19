using Services_Repos.Models.Data_Classes;
using Services_Repos.Data;


namespace Services_Repos.Models.Repositories;

public class CategoryRepository(AppDbContext dbContext) : IRepository<Category>
{
    
    private readonly AppDbContext _dbContext = dbContext;
    //private List<Category> _categories = [];
    public void Add(Category item)
    {
        _dbContext.Categories.Add(item);
        _dbContext.SaveChanges();
    }

    public List<Category> GetAll() => [.. _dbContext.Categories];

    public Category GetById(int id) => _dbContext.Categories.Find(id);

    public void Remove(Category item)
    {
        _dbContext.Categories.Remove(item);
        _dbContext.SaveChanges();
    }

    public void Update(Category item)
    {
        _dbContext.Categories.Update(item);
        _dbContext.SaveChanges();
    }
}

