using CommunityToolkit.Mvvm.ComponentModel;
using Services_Repos.Models.Data_Classes;
using Services_Repos.Services;
using LiveCharts;
using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.Mvvm.Messaging;


namespace CatalogoWPF.ViewModels;

partial class ChartsViewModel : ObservableObject
{
    private readonly IService<Category> categService;
    public ChartsViewModel(IService<Category> categService)
    {
        this.categService = categService;
        IEnumerable<Category> categories = categService.GetAll();
        ChartValues = new ChartValues<int>(categories.Select(c => c.Products.Count));
        CategoryNames = categories.Select(c => c.Name).ToArray();
        WeakReferenceMessenger.Default.Register<ValueChangedMessage<string>>(this, (r, m) =>
        {
            RefreshCollection();
        });
    }


    [ObservableProperty]
    ChartValues<int> _chartValues;

    [ObservableProperty]
    string[] _categoryNames;

    private void RefreshCollection()
    {
        IEnumerable<Category> categories = categService.GetAll();
        ChartValues =  new ChartValues<int>(categories.Select(c => c.Products.Count));
        CategoryNames = categories.Select(c => c.Name).ToArray();
    }
}
