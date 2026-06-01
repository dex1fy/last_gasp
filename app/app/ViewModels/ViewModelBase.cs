using app.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace app.ViewModels
{
    public abstract class ViewModelBase : ObservableObject
    {
        public static PostgresContext db = new PostgresContext();

    }
}
