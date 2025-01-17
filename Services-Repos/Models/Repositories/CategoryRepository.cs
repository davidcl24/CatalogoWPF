using Services_Repos.Models.Data_Classes;
using Services_Repos.Data;


namespace Services_Repos.Models.Repositories;

public class CategoryRepository(AppDbContext dbContext) : IRepository<Category>
{
    
    private readonly AppDbContext _dbContext = dbContext;
    //private List<Category> _categories = [];
    public void Add(Category item) => _dbContext.Add(item);

    public List<Category> GetAll() => [.. _dbContext.Categories];

    public Category GetById(int id) => _dbContext.Find<Category>(id);

    public void Remove(Category item) => _dbContext.Remove(item);

    public void Update(Category item) => _dbContext.Update(item);
}

