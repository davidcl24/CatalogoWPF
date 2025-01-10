using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CatalogoWPF.ViewModels;

partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private object _activeView;


    public HomeViewModel HomeViewModel { get; set; } = new();
    public DetailViewModel DetailViewModel { get; set; } = new();
    public SettingsViewModel SettingsViewModel { get; set; } = new();

    public MainViewModel() => _activeView = HomeViewModel;

    [RelayCommand]
    private void ActivateHomeView() => ActiveView = HomeViewModel;
    [RelayCommand]
    private void ActivateDetailView() => ActiveView = DetailViewModel;
    [RelayCommand]
    private void ActivateSettingsView() => ActiveView = SettingsViewModel;
    
}
