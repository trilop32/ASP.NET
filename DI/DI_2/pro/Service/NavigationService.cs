using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModel;

namespace WpfApp1.Service
{
    public interface INavogationService
    {
        BasePageViewModel? basePageViewModel { get; }
        void NavigateTo<T>() where T: BasePageViewModel;
    }
    public class NavigationService(Func<Type, BasePageViewModel> factoryPageViewMadel) : ObservableObject, INavogationService
    {
        private BasePageViewModel? basePageViewModel;
        public BasePageViewModel? BasePageViewModel
        {
            get => basePageViewModel;
            private set
            {
                basePageViewModel=value;
            }
        }
        public void NavigatoTo<T>() where T: BasePageViewModel
        {
            if(BasePageViewModel is not T)
            {
                BasePageViewModel = factoryPageViewMadel.Invoke(typeof(T));
            }
        }
    }
}
