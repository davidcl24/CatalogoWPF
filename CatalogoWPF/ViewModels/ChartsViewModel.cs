using CommunityToolkit.Mvvm.ComponentModel;
using Services_Repos.Models.Data_Classes;
using Services_Repos.Services;
using LiveCharts;
using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using LiveCharts.Wpf;


namespace CatalogoWPF.ViewModels;

partial class ChartsViewModel : ObservableObject
{
    private readonly IService<Category> categService;

    [ObservableProperty]
    private SeriesCollection _series = [];
    public ChartsViewModel(IService<Category> categService)
    {
        this.categService = categService;
        ConfigChart();

        WeakReferenceMessenger.Default.Register<ValueChangedMessage<string>>(this, (r, m) =>
        {
            ConfigChart();
        });
    }

    private void ConfigChart()
    {
        Series.Clear();
        IEnumerable<Category> categories = categService.GetAll();
       
        foreach (var category in categories)
        {
            Series.Add(new PieSeries
            {
                Title = category.Name,
                Name = category.Name,
                Values = new ChartValues<int> { category.Products.Count }
            });
        }
    }



}
