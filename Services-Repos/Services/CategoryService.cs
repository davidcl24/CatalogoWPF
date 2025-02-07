using Services_Repos.Models.Data_Classes;
using Services_Repos.Rest;

namespace Services_Repos.Services;

public class CategoryService(IRestClient<Category> categClient) : IService<Category>
{ 

    public void Add(Category item)
    {
        //Category categ = categRepository.GetById(item.Id);

        //if (categ is null)
        //{
        //    categRepository.Add(item);
        //}
        //else
        //{
        //    throw new CategoryException("A category with this ID already exists");
        //}
    }

    public void Remove(int id)
    {
        //Category category = categRepository.GetById(id);
        //if (category is not null)
        //{
        //    categRepository.Remove(category);
        //}
        //else
        //{
        //    throw new CategoryException("No category with this ID");
        //}
    }

    public Category GetById(int id)
    {
        //Category categ = categRepository.GetById(id);

        //if (categ is null)
        //{
        //    throw new CategoryException("No category with this ID");
        //}
        //else
        //{
        //    return categ;
        //}
        return null;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await categClient.RefreshDataAsync();
    }

    public void Update(Category c)
    {
        //Category ca = GetById(c.Id);
        //if (ca is null)
        //{
        //    throw new CategoryException("No category with this ID");
        //}
        //else
        //{
        //    categRepository.Update(c);
        //}
    }
}
