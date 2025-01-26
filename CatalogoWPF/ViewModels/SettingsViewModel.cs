using CatalogoWPF.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Services_Repos.Services;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows;

namespace CatalogoWPF.ViewModels;

partial class SettingsViewModel : ObservableObject
{

    private readonly SettingsService settingsService;

    [ObservableProperty]
    ObservableCollection<string> _cultures = [];

    [ObservableProperty]
    string _selectedCulture = CultureInfo.CurrentCulture.ToString();

    public SettingsViewModel(SettingsService settingsService)
    {
        this.settingsService = settingsService;
        SettingsPropertyCollection list = Properties.Settings.Default.Properties;
        foreach (SettingsProperty property in list)
        {
            Cultures.Add((string)property.DefaultValue);
        }
    }

    [RelayCommand]
    private void ChangeLang() => settingsService.ChangeLang(new CultureInfo(SelectedCulture));

    [RelayCommand]
    //private void ChangeLang()
    //{
    //    CultureInfo culture = new(SelectedCulture);
    //    MessageBox.Show(CultureInfo.CurrentCulture.ToString());
    //    CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en");
    //    CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
    //    MessageBox.Show(CultureInfo.CurrentCulture.ToString());
    //}
}
