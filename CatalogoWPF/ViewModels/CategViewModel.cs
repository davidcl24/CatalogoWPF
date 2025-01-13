using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Services_Repos.Models.Data_Classes;
using Services_Repos.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace CatalogoWPF.ViewModels;

partial class CategViewModel : ObservableObject
{

    private CategoryService categoryService = new();
    private int currentId;

    [ObservableProperty]
    ObservableCollection<Category> _categories;

    [ObservableProperty]
    string _name;

    public CategViewModel()
    {
        _categories = new(categoryService.GetAll());
        currentId = categoryService.GetAll().Count();
    }

    [RelayCommand]
    private void Add()
    {
        categoryService.Add(new Category(currentId++, Name));
        RefreshCollection();
    }


    private void RefreshCollection()
    {
        _categories = new(categoryService.GetAll());
    }

}
