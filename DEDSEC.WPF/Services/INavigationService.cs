using DEDSEC.WPF.ViewModels;

namespace DEDSEC.WPF.Services
{
    public interface INavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        void Navigate();
    }
}
