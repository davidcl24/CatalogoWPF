using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.Mvvm.Messaging;
using Services_Repos.Models.Data_Classes;
using Services_Repos.Services;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace CatalogoWPF.ViewModels;

partial class HomeViewModel : ObservableObject
{
    private readonly IService<Product> productService;
    private readonly IService<Category> categService;
    public HomeViewModel(IService<Product> productService, IService<Category> categService)
    {
        this.productService = productService;
        this.categService = categService;
        Products = new(productService.GetAll().Select(c => c.ImageUrl).ToList());
        Categories = new(categService.GetAll().Select(c => c.ImgUrl).ToList());

        WeakReferenceMessenger.Default.Register<ValueChangedMessage<string>>(this, (r, m) =>
        {
            RefreshCollection();
        });
    }


    [ObservableProperty]
    ObservableCollection<string> _products;

    [ObservableProperty]
    ObservableCollection<string> _categories;


    private void RefreshCollection()
    {
        Categories = new(categService.GetAll().Select(c => c.ImgUrl).ToList());
        Products = new(productService.GetAll().Select(c => c.ImageUrl).ToList());
    }
}
