using Services_Repos.Exceptions;
using Services_Repos.Models.Data_Classes;
using Services_Repos.Models.Repositories;

namespace Services_Repos.Services;

public class ProductService
{
    public int ProductId { get; set; }
    private ProductRepository productRepository;

    public ProductService(ProductRepository productRepository)
    {
        ProductId = 1;
        this.productRepository = productRepository;
    }

    public void Add(Product item)
    {
        Product producto = productRepository.GetById(item.Id);

        if (producto is null)
        {
            productRepository.Add(item);
        }
        else
        {
            throw new ProductException("A product with this ID already exists");
        }
    }

    public void Remove(int id)
    {
        Product p = productRepository.GetById(id);
        if (p is not null)
        {
            productRepository.Remove(p);
        }
        else
        {
            throw new ProductException("No product with this ID");
        }
    }

    public Product GetById(int id)
    {
        Product p = productRepository.GetById(id);
        if (p is null)
        {
            throw new ProductException("No product is associated with given ID");
        }
        else
        {
            return p;
        }
    }

    public List<Product> GetAll()
    {
        List<Product> list = productRepository.GetAll();
        if (list.Count > 0)
        {
            return list;
        }
        else
        {
            throw new ProductException("No products stored");
        }
    }

    public void Update(Product p)
    {
        Product pr = GetById(p.Id);
        if (pr is null)
        {
            throw new ProductException("No product with this given ID");
        }
        else
        {
            productRepository.Update(p);
        }
    }
}