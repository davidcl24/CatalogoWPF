using CommunityToolkit.Mvvm.ComponentModel;
using Microcharts;
using Services_Repos.Models.Data_Classes;
using Services_Repos.Services;
using SkiaSharp;
using System.Collections.ObjectModel;

namespace CatalogoWPF.ViewModels;

partial class ChartsViewModel : ObservableObject
{
    private readonly IService<Product> productService;
    private readonly IService<Category> categService;
    public ChartsViewModel(IService<Product> productService, IService<Category> categService)
    {
        this.productService = productService;
        this.categService = categService;
        Products = new ObservableCollection<Product>(productService.GetAll());
        Categories = new ObservableCollection<Category>(categService.GetAll());
        List<ChartEntry> entries = [];
        var random = new Random();
        foreach (Category category in categService.GetAll())
        {
            entries.Add(new(category.Products.Count)
            {
                Label = category.Name,
                ValueLabel = category.Products.Count.ToString(),
                Color = SKColor.Parse($"#{random.Next(0x1000000):X6}")
            });
        }
        Chart = new BarChart()
        {
            Entries = entries
        };
    }

    [ObservableProperty]
    ObservableCollection<Product> _products;

    [ObservableProperty]
    ObservableCollection<Category> _categories;

    [ObservableProperty]
    BarChart _chart;

    private void RefreshCollection()
    {
        Categories = new(categService.GetAll());
        Products = new(productService.GetAll());
    }
}
