using CommunityToolkit.Mvvm.ComponentModel;
using Services_Repos.Models.Data_Classes;
using Services_Repos.Services;
using System.Collections.ObjectModel;

namespace CatalogoWPF.ViewModels;

partial class CategViewModel : ObservableObject
{

    private CategoryService categoryService = new();

    [ObservableProperty]
    ObservableCollection<Category> _categories;

    public CategViewModel() => _categories = new(categoryService.GetAll());
}
