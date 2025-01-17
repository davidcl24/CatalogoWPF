using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CatalogoWPF.ViewModels;

partial class MainViewModel(CategViewModel categViewModel,
                            ProductViewModel productViewModel,
                            SettingsViewModel settingsViewModel) : ObservableObject
{
    [ObservableProperty]
    private object _activeView = categViewModel;

    public CategViewModel CategViewModel { get; set; } = categViewModel;
    public ProductViewModel ProductViewModel { get; set; } = productViewModel;
    public SettingsViewModel SettingsViewModel { get; set; } = settingsViewModel;

    [RelayCommand]
    private void ActivateProductView() => ActiveView = ProductViewModel;

    [RelayCommand]
    private void ActivateCategView() => ActiveView = CategViewModel;

    [RelayCommand]
    private void ActivateSettingsView() => ActiveView = SettingsViewModel;
    
}
