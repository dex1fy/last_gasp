using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.ViewModels
{
    public partial class AuthViewModel : ViewModelBase
    {
        [ObservableProperty] string login;
        [ObservableProperty] string password;
        [ObservableProperty] string message;

        public void Enter()
        {
            MainWindowViewModel.Instance.currentUser = db.Users.FirstOrDefault(x => x.Login == Login && x.Password == Password);

            if (MainWindowViewModel.Instance.currentUser == null)
            {
                Message = "Пользователь не найден";
            }
            else
            {
                switch(MainWindowViewModel.Instance.currentUser.RoleId)
                {
                    case 1: 
                        MainWindowViewModel.Instance.PageSwitcher = new AdminViewModel();
                        break;
                    case 2:
                        MainWindowViewModel.Instance.PageSwitcher = new ManagerViewModel();
                        break;
                    case 3:
                        MainWindowViewModel.Instance.PageSwitcher= new UserViewModel();
                        break;
                }
                

            }

        }

        public void Guest ()
        {
            
                MainWindowViewModel.Instance.PageSwitcher = new UserViewModel();

        }


    }
}
