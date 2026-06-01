using app.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

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

        public  Stack<ViewModelBase> prevPages = new Stack<ViewModelBase>();
        public bool routeFlag = true;
        partial void OnPageSwitcherChanged(ViewModelBase? oldValue, ViewModelBase newValue)
        {   
            if (routeFlag == true)
            {
                prevPages.Push(oldValue);
                routeFlag = true;
            }

            
        }
    }
}
