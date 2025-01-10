using Services_Repos.Exceptions;
using Services_Repos.Models.Data_Classes;
using Services_Repos.Models.Repositories;

namespace Services_Repos.Services;

public class CategoryService
{
    public int CategoryId { get; set; }
    private CategoryRepository categRepository;

    public CategoryService()
    {
        CategoryId = 1;
        this.categRepository = new();
    }

    public void Add(Category item)
    {
        Category categ = categRepository.GetById(item.Id);

        if (categ is null)
        {
            categRepository.Add(item);
        }
        else
        {
            throw new CategoryException("A category with this ID already exists");
        }
    }

    public void Remove(int id)
    {
        Category category = categRepository.GetById(id);
        if (category is not null)
        {
            categRepository.Remove(category);
        }
        else
        {
            throw new CategoryException("No category with this ID");
        }
    }

    public Category GetById(int id)
    {
        Category categ = categRepository.GetById(id);

        if (categ is null)
        {
            throw new CategoryException("No category with this ID");
        }
        else
        {
            return categ;
        }
    }

    public List<Category> GetAll()
    {
        List<Category> list = categRepository.GetAll();
        if (list.Count > 0)
        {
            return list;
        }
        else
        {
            throw new CategoryException("No categories stored");
        }
    }

    public void Update(Category c)
    {
        Category ca = GetById(c.Id);
        if (ca is null)
        {
            throw new CategoryException("No category with this ID");
        }
        else
        {
            categRepository.Update(c);
        }
    }
}
