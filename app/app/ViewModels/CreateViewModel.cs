using app.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.ViewModels
{
    public partial class CreateViewModel : ViewModelBase
    {

        [ObservableProperty]
        Product addProduct = new Product()
        {
            Price = 0,
            CurrentDiscount = 0,
            StockQuantity = 0
        };

        [ObservableProperty] List<Category> categories = db.Categories.ToList();
        [ObservableProperty] List<ProductType> type = db.ProductTypes.ToList();
        [ObservableProperty] List<Unit> units = db.Units.ToList();
        [ObservableProperty] List<Supplier> suppliers = db.Suppliers.ToList();
        [ObservableProperty] List<Manufacturer> manufacturers = db.Manufacturers.ToList();


        public void Cancel()
        {
            MainWindowViewModel.Instance.PageSwitcher = new AdminViewModel();
        }

        public void Save()
        {
            db.Products.Add(AddProduct);
            db.SaveChanges();
            MainWindowViewModel.Instance.PageSwitcher = new AdminViewModel();
        }


    }
}
