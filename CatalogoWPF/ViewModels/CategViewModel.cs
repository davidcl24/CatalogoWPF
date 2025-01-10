using CommunityToolkit.Mvvm.ComponentModel;
using Services_Repos.Models.Data_Classes;
using Services_Repos.Services;

namespace CatalogoWPF.ViewModels;

partial class CategViewModel : ObservableObject
{

    private CategoryService categoryService = new();

    [ObservableProperty]
    List<Category> _categories;

    public CategViewModel() => _categories = categoryService.GetAll();
}
