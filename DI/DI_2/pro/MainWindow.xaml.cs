using System.Windows;
using WpfApp1.ViewModel;
namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext=new MainWindowViewModel();
        }
    }
}
