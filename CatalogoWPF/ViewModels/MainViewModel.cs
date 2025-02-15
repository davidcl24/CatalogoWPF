﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CatalogoWPF.ViewModels;

partial class MainViewModel(CategViewModel categViewModel,
                            ProductViewModel productViewModel,
                            SettingsViewModel settingsViewModel,
                            ChartsViewModel chartsViewModel,
                            HomeViewModel homeViewModel) : ObservableObject
{
    [ObservableProperty]
    private object _activeView = homeViewModel;

    public CategViewModel CategViewModel { get; set; } = categViewModel;
    public ProductViewModel ProductViewModel { get; set; } = productViewModel;
    public SettingsViewModel SettingsViewModel { get; set; } = settingsViewModel;
    public ChartsViewModel ChartsViewModel { get; set; } = chartsViewModel;
    public HomeViewModel HomeViewModel { get; set; } = homeViewModel;

    [RelayCommand]
    private void ActivateProductView() => ActiveView = ProductViewModel;

    [RelayCommand]
    private void ActivateCategView() => ActiveView = CategViewModel;

    [RelayCommand]
    private void ActivateSettingsView() => ActiveView = SettingsViewModel;

    [RelayCommand]
    private void ActivateChartsView() => ActiveView = ChartsViewModel;

    [RelayCommand]
    private void ActivateHomeView() => ActiveView = HomeViewModel;

}
