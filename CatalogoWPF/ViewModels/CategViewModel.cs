using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Services_Repos.Exceptions;
using Services_Repos.Models.Data_Classes;
using Services_Repos.Services;
using System.Collections.ObjectModel;

namespace CatalogoWPF.ViewModels;

partial class CategViewModel (IService<Category> categoryService) : ObservableObject
{

    [ObservableProperty]
    ObservableCollection<Category> _categories = new(categoryService.GetAll());

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Categories))]
    [NotifyPropertyChangedFor(nameof(IsCategSelected))]
    [NotifyCanExecuteChangedFor(nameof(AddCommand))]
    [NotifyCanExecuteChangedFor(nameof(RemoveCommand))]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    Category? _selectedCategory;

    private bool IsCategSelected => SelectedCategory is not null;


    [RelayCommand]
    private void Add() => SelectedCategory = new("");


    [RelayCommand(CanExecute = nameof(IsCategSelected))]
    private void Save()
    {
        try
        {
            categoryService.GetById(SelectedCategory.Id);
            categoryService.Update(SelectedCategory);
            SendMessage();
        }
        catch (CategoryException ex) {
        
            categoryService.Add(SelectedCategory);
            SendMessage();
        }
       
        SelectedCategory = null;
        RefreshCollection();
    }

    [RelayCommand(CanExecute = nameof (IsCategSelected))]
    private void Remove()
    {
        categoryService.Remove(SelectedCategory.Id);
        RefreshCollection();
        SelectedCategory = null;
        SendMessage();
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
