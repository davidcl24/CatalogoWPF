using CommunityToolkit.Mvvm.ComponentModel;
using Services_Repos.Models.Data_Classes;
using Services_Repos.Services;
using System.Collections.ObjectModel;

namespace CatalogoWPF.ViewModels;

partial class ProductViewModel : ObservableObject
{
    private ProductService productService = new();

    [ObservableProperty]
    ObservableCollection<Product> _products;

    public ProductViewModel() => _products = new(productService.GetAll());
}
