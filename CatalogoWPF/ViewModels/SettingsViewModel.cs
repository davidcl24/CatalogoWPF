using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
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
