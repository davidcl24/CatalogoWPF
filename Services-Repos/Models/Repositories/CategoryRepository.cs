using Services_Repos.Models.Data_Classes;

namespace Services_Repos.Models.Repositories;

public class CategoryRepository : IRepository<Category>
{
    private List<Category> _categories = [new(1, "Categ1"), new(2, "Categ2")];
    public void Add(Category item) => _categories.Add(item);

    public List<Category> GetAll() => _categories;

    public Category GetById(int id) => _categories.Find(c => c.Id == id);

    public void Remove(Category item) => _categories.Remove(item);

    public void Update(Category item)
    {
        Category? categ = _categories.Find(c => c.Id == item.Id);
        if (categ != null)
        {
            categ.Id = item.Id;
            categ.Name = item.Name;
            categ.Products = item.Products;
        }
    }
}

