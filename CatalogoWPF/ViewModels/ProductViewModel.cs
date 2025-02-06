using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Services_Repos.Exceptions;
using Services_Repos.Models.Data_Classes;
using Services_Repos.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace CatalogoWPF.ViewModels;

partial class ProductViewModel : ObservableObject
{
   
    private readonly IService<Product> productService;
    private readonly IService<Category> categService;

    public ProductViewModel(IService<Product> productService, IService<Category> categService)
    {
        this.productService = productService;
        this.categService = categService;
        Products = new ObservableCollection<Product>(productService.GetAll());
        Categories = new ObservableCollection<Category>(categService.GetAll());

        WeakReferenceMessenger.Default.Register<ValueChangedMessage<string>>(this, (r, m) =>
        {
            RefreshCollection();
        });
    }

    [ObservableProperty]
    ObservableCollection<Product> _products;

    [ObservableProperty]
    ObservableCollection<Category> _categories;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Categories))]
    [NotifyPropertyChangedFor(nameof(IsProdSelected))]
    [NotifyPropertyChangedFor(nameof(NotIdZero))]
    [NotifyCanExecuteChangedFor(nameof(AddCommand))]
    [NotifyCanExecuteChangedFor(nameof(RemoveCommand))]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    Product? _selectedProduct;

    //[ObservableProperty]
    //Category? _selectedCategory;

    public bool IsProdSelected => SelectedProduct is not null;

    private bool NotIdZero => SelectedProduct is not null && SelectedProduct.Id != 0;


    [RelayCommand]
    private void Add() => SelectedProduct = new();

    [RelayCommand(CanExecute = nameof(IsProdSelected))]
    private void Save()
    {
        try
        {
            productService.GetById(SelectedProduct.Id);
            productService.Update(SelectedProduct);
            SendMessage();
        }
        catch (ProductException)
        {
            if (SelectedProduct.Category is not null)
            {
                productService.Add(SelectedProduct);
                SendMessage();
            } else
            {
                MessageBox.Show("Category cannot be empty");
            }
         
        }

       // SelectedCategory = null;
        SelectedProduct = null;
        RefreshCollection();
    }

    [RelayCommand(CanExecute = nameof(NotIdZero))]
    private void Remove()
    {
        try
        {
            productService.Remove(SelectedProduct.Id);
            RefreshCollection();
            SelectedProduct = null;
            SendMessage();
        }
        catch (ProductException ex)
        {
            MessageBox.Show(ex.Message);
            SelectedProduct = null;
        }
        
    }

    private void SendMessage()
    {
        WeakReferenceMessenger.Default.Send(new ValueChangedMessage<string>("Model Changed"));
    }
    private void RefreshCollection()
    {
       Categories = new(categService.GetAll());
       Products = new(productService.GetAll());
    }

}
