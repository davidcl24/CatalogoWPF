using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Services_Repos.Models.Data_Classes;
using Services_Repos.Services;
using System.Collections.ObjectModel;

namespace CatalogoWPF.ViewModels;

partial class ProductViewModel (IService<Product> productService,
                                IService<Category> categService) : ObservableObject
{



    [ObservableProperty]
    ObservableCollection<Product> _products = new(productService.GetAll());

    [ObservableProperty]
    ObservableCollection<Category> _categories = new(categService.GetAll());

    [ObservableProperty]
    string _name;
    [ObservableProperty]
    string _description;
    [ObservableProperty]
    decimal _price;

    [RelayCommand]
    private void Add()
    {
        //productService.Add(new Product(currentId++, 0, Name, Description, Price));
        RefreshCollection();
        Name = "";
        Description = "";
        Price = 0;
    }

    private void RefreshCollection()
    {
       Products = new(productService.GetAll());
    }

}
