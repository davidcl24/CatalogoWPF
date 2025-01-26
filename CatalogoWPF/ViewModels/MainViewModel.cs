using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CatalogoWPF.ViewModels;

partial class MainViewModel(CategViewModel categViewModel,
                            ProductViewModel productViewModel,
                            SettingsViewModel settingsViewModel,
                            ChartsViewModel chartsViewModel) : ObservableObject
{
    [ObservableProperty]
    private object _activeView = categViewModel;

    public CategViewModel CategViewModel { get; set; } = categViewModel;
    public ProductViewModel ProductViewModel { get; set; } = productViewModel;
    public SettingsViewModel SettingsViewModel { get; set; } = settingsViewModel;
    public ChartsViewModel ChartsViewModel { get; set; } = chartsViewModel;

    [RelayCommand]
    private void ActivateProductView() => ActiveView = ProductViewModel;

    [RelayCommand]
    private void ActivateCategView() => ActiveView = CategViewModel;

    [RelayCommand]
    private void ActivateSettingsView() => ActiveView = SettingsViewModel;

    [RelayCommand]
    private void ActivateChartsView() => ActiveView = ChartsViewModel;

}
