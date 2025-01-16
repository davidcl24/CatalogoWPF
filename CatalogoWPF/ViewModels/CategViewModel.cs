using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Services_Repos.Models.Data_Classes;
using Services_Repos.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace CatalogoWPF.ViewModels;

partial class CategViewModel (IService<Category> categoryService) : ObservableObject
{

    [ObservableProperty]
    ObservableCollection<Category> _categories = new(categoryService.GetAll());

    [ObservableProperty]
    string _name;



    [RelayCommand]
    private void Add()
    {
        categoryService.Add(new Category(currentId++, Name));
        RefreshCollection();
        Name = "";
    }


    private void RefreshCollection()
    {
        Categories = new(categoryService.GetAll());
    }

}
