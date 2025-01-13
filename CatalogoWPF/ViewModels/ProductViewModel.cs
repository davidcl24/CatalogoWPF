using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Services_Repos.Models.Data_Classes;
using Services_Repos.Services;
using System.Collections.ObjectModel;

namespace CatalogoWPF.ViewModels;

partial class ProductViewModel : ObservableObject
{
    private ProductService productService = new();
    private int currentId;


    [ObservableProperty]
    ObservableCollection<Product> _products;

    [ObservableProperty]
    string _name;
    [ObservableProperty]
    string _description;
    [ObservableProperty]
    decimal _price;

    public ProductViewModel()
    {
        _products = new(productService.GetAll());
        currentId = productService.GetAll().Count();
    }

    [RelayCommand]
    private void Add()
    {
        productService.Add(new Product(currentId++, 0, Name, Description, Price));
        RefreshCollection();
    }

    private void RefreshCollection()
    {
        _products = new(productService.GetAll());
    }

}
