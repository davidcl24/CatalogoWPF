using CommunityToolkit.Mvvm.ComponentModel;
using Services_Repos.Models.Data_Classes;
using Services_Repos.Services;

namespace CatalogoWPF.ViewModels;

partial class ProductViewModel : ObservableObject
{
    private ProductService productService = new();

    [ObservableProperty]
    List<Product> _products;

    public ProductViewModel() => _products = productService.GetAll();
}
