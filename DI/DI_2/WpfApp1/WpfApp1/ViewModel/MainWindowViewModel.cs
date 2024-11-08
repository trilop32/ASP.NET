using WpfApp1.ViewModel.Pages;
using GalaSoft.MvvmLight.Command;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
namespace WpfApp1.ViewModel
{
    public class MainWindowViewModel:INotifyPropertyChanged
    {
        private BasePageViewModel basePageViewModel;
        public BasePageViewModel BasePageViewModel
        {
            get { return basePageViewModel; }
            set {  basePageViewModel = value; OnPropertyChanged(); }
        }
        public RelayCommand NavigateToMenuCommand { get; set; }
        public RelayCommand NavigateToHomeCommand { get; set; }
        public MainWindowViewModel()
        {
            NavigateToMenuCommand = new(NavigateToMenu);
            NavigateToHomeCommand = new(NavigateToHome);
            basePageViewModel = new MenuPageViewModel();
        }
        public void NavigateToMenu(object? obj)
        {
            BasePageViewModel = new MenuPageViewModel();
        }
        public void NavigateToHome(object? obj)
        {
            BasePageViewModel = new HomePageViewModel();
        }
        public event ProcessInputEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
