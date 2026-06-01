using app.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace app.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty] ViewModelBase pageSwitcher = new AuthViewModel();

        public static MainWindowViewModel Instance { get; set; }

        public MainWindowViewModel()
        {
            Instance = this;
        }

        public User currentUser;
    }
}
