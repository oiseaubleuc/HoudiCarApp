using HoudiCarApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyCarApp;
using System;
using System.Windows;

namespace HoudiCarApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();
            services.AddDbContext<CarDealershipContext>(options =>
                options.UseSqlite("Data Source=CarDealership.db"));

            var serviceProvider = services.BuildServiceProvider();
            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
