using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CatalogoWPF.ViewModels;

partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private object _activeView;

    public CategViewModel CategViewModel { get; set; } = new();
    public ProductViewModel ProductViewModel { get; set; } = new();
    public SettingsViewModel SettingsViewModel { get; set; } = new();

    public MainViewModel() => _activeView = CategViewModel;


    [RelayCommand]
    private void ActivateProductView() => ActiveView = ProductViewModel;

    [RelayCommand]
    private void ActivateCategView() => ActiveView = CategViewModel;

    [RelayCommand]
    private void ActivateSettingsView() => ActiveView = SettingsViewModel;
    
}
