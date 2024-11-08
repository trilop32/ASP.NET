using GalaSoft.MvvmLight.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WpfApp1.Service;
using WpfApp1.ViewModel;
using WpfApp1.ViewModel.Pages;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider serviceProvider;
        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton(provder => new MainWindow
            {
                DataContext= provder.GetService<MainWindowViewModel>()
            });
            services.AddSingleton<HomePageViewModel>();
            services.AddSingleton<MenuPageViewModel>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<INavigationService, NavigationService>();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
