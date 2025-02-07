using CatalogoWPF.ViewModels;
using CatalogoWPF.Views;
using Microsoft.Extensions.DependencyInjection;
using Services_Repos.Models.Data_Classes;
using Services_Repos.Rest;
using Services_Repos.Services;
using System.Windows;

namespace CatalogoWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ServiceCollection services = new();

            services.AddTransient<MainWindow>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<HomeView>();
            services.AddTransient<HomeViewModel>();
            services.AddTransient<CategView>();
            services.AddTransient<CategViewModel>();
            services.AddTransient<ProductView>();
            services.AddTransient<ProductViewModel>();
            services.AddTransient<SettingsView>();
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<ChartsView>();
            services.AddTransient<ChartsViewModel>();
            services.AddScoped<IRestClient<Product>, RestClientProduct>();
            services.AddScoped<IRestClient<Category>, RestClientCategory>();
            services.AddScoped<IService<Product>, ProductService>();
            services.AddScoped<IService<Category>, CategoryService>();
            
            var serviceProvider = services.BuildServiceProvider();

       

            var view = serviceProvider.GetService<MainWindow>();
            view!.DataContext = serviceProvider.GetService<MainViewModel>();
            view.Show();
        }
    }

}
