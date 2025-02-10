using Services_Repos.Models.Data_Classes;
using Services_Repos.Rest;

namespace Services_Repos.Services;

public class ProductService(IRestClient<Product> productClient) : IService<Product>
{

    public void Add(Product item)
    {
        //Product producto = productRepository.GetById(item.Id);

        //if (producto is null) 
        //{
        //    productRepository.Add(item);
        //}
        //else
        //{
        //    throw new ProductException("A product with this ID already exists");
        //}
    }

    public void Remove(int id)
    {
        //Product p = productRepository.GetById(id);
        //if (p is not null)
        //{
        //    productRepository.Remove(p);
        //}
        //else
        //{
        //    throw new ProductException("No product with this ID");
        //}
    }

    public Product GetById(int id)
    {
        //Product p = productRepository.GetById(id);
        //if (p is null)
        //{
        //    throw new ProductException("No product is associated with given ID");
        //}
        //else
        //{
        //    return p;
        //}
        return null;
    }

    public  async Task<List<Product>> GetAllAsync()
    {
        return await productClient.RefreshDataAsync();
      
    }
    public void Update(Product p)
    {
        //Product pr = GetById(p.Id);
        //if (pr is null)
        //{
        //    throw new ProductException("No product with this given ID");
        //}
        //else
        //{
        //    productRepository.Update(p);
        //}
    }
}