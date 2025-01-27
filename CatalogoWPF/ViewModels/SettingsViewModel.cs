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


    [ObservableProperty]
    ObservableCollection<string> _cultures = [];

    [ObservableProperty]
    string _selectedCulture = Properties.Settings.Default.Language;

    public SettingsViewModel() => Cultures = ["es", "en"];

    [RelayCommand]
    private void ChangeLang()
    {
        Properties.Settings.Default.Language = SelectedCulture;
        Properties.Settings.Default.Save();
        MessageBox.Show(Properties.Resources.ResetMsg);
    }


}
