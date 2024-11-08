using WpfApp1.ViewModel.Pages;
using GalaSoft.MvvmLight.Command;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Navigation;
using GalaSoft.MvvmLight.Views;
namespace WpfApp1.ViewModel
{
    public class MainWindowViewModel
    {
        public NavigationService NavigationService {get;}
        public RelayCommand NavigateToMenuCommand { get; set; }
        public RelayCommand NavigateToHomeCommand { get; set; }
        public MainWindowViewModel(INavigationService navigationService)
        {
            NavigateToMenuCommand = new(x => navigationService.NavigateTo<MenuPageViewModel>);
            NavigateToHomeCommand = new(x => navigationService.NavigateTo<HomePageViewModel>);
        }
        
        //public event ProcessInputEventHandler? PropertyChanged;
        //public void OnPropertyChanged([CallerMemberName] string propertyName="")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
