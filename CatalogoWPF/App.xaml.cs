using CatalogoWPF.ViewModels;
using CatalogoWPF.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services_Repos.Data;
using Services_Repos.Models.Data_Classes;
using Services_Repos.Models.Repositories;
using Services_Repos.Services;
using System;
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
            services.AddTransient<CategView>();
            services.AddTransient<CategViewModel>();
            services.AddTransient<ProductView>();
            services.AddTransient<ProductViewModel>();
            services.AddTransient<SettingsView>();
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<ChartsView>();
            services.AddTransient<ChartsViewModel>();
            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<IRepository<Category>, CategoryRepository>();
            services.AddScoped<IService<Product>, ProductService>();
            services.AddScoped<IService<Category>, CategoryService>();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Server=localhost, 1433;Database=prodDB;User Id=sa;Password=Interfaces-2425;TrustServerCertificate=true;"));
            var serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated();

            }


            var view = serviceProvider.GetService<MainWindow>();
            view!.DataContext = serviceProvider.GetService<MainViewModel>();
            view.Show();
        }
    }

}
