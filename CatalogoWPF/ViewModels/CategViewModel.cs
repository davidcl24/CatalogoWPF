using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Services_Repos.Exceptions;
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
    bool _isSelected = false;


    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Categories))]
    [NotifyPropertyChangedFor(nameof(IsCategSelected))]
    [NotifyPropertyChangedFor(nameof(NotIdZero))]
    [NotifyCanExecuteChangedFor(nameof(AddCommand))]
    [NotifyCanExecuteChangedFor(nameof(RemoveCommand))]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    Category? _selectedCategory;

    public bool IsCategSelected => SelectedCategory is not null;

    private bool NotIdZero => SelectedCategory is not null && SelectedCategory.Id != 0;



    [RelayCommand]
    private void Add() => SelectedCategory = new("", "");


    [RelayCommand(CanExecute = nameof(IsCategSelected))]
    private void Save()
    {
        try
        {
            categoryService.GetById(SelectedCategory.Id);
            categoryService.Update(SelectedCategory);
            SendMessage();
        }
        catch (CategoryException) {
        
            categoryService.Add(SelectedCategory);
            SendMessage();
        }
       
        SelectedCategory = null;
        RefreshCollection();
    }

    [RelayCommand(CanExecute = nameof (NotIdZero))]
    private void Remove()
    {
        try
        {
            categoryService.Remove(SelectedCategory.Id);
            RefreshCollection();
            SelectedCategory = null;
            SendMessage();
        }
        catch (CategoryException ex)
        {
            MessageBox.Show(ex.Message);
            SelectedCategory = null;
        }
       
    }
    private void SendMessage()
    {
        WeakReferenceMessenger.Default.Send(new ValueChangedMessage<string>("Model Changed"));
    }

    private void RefreshCollection()
    {
        Categories = new(categoryService.GetAll());
    }

}
