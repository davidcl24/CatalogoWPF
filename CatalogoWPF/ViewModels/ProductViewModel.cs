using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Services_Repos.Exceptions;
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
    [NotifyPropertyChangedFor(nameof(Categories))]
    [NotifyPropertyChangedFor(nameof(IsProdSelected))]
    [NotifyCanExecuteChangedFor(nameof(AddCommand))]
    [NotifyCanExecuteChangedFor(nameof(RemoveCommand))]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    Product? _selectedProduct;

    //[ObservableProperty]
    //Category? _selectedCategory;

    private bool IsProdSelected => SelectedProduct is not null;

    [RelayCommand]
    private void Add() => SelectedProduct = new(0, "", "", 0);

    [RelayCommand(CanExecute = nameof(IsProdSelected))]
    private void Save()
    {
        try
        {
            productService.GetById(SelectedProduct.Id);
            productService.Update(SelectedProduct);
        }
        catch (ProductException ex)
        {
            productService.Add(SelectedProduct);
        }

       // SelectedCategory = null;
        SelectedProduct = null;
        RefreshCollection();
    }

    [RelayCommand(CanExecute = nameof(IsProdSelected))]
    private void Remove()
    {
        productService.Remove(SelectedProduct.Id);
        RefreshCollection();
        SelectedProduct = null;
    }

    private void RefreshCollection()
    {
       Categories = new(categService.GetAll());
       Products = new(productService.GetAll());
    }

}
