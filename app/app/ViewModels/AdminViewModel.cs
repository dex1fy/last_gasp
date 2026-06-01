using app.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.ViewModels
{
    public partial class AdminViewModel : ViewModelBase
    {
        [ObservableProperty] int selectedDiscountFilter = -1;

        [ObservableProperty]
        List<Product> products = db.Products
        .Include(p => p.ProductType)
        .Include(p => p.Unit)
        .Include(p => p.Supplier)
        .Include(p => p.Manufacturer)
        .Include(p => p.Category)
        .ToList();


        public List<Product> Products0 => db.Products
        .Include(p => p.ProductType)
        .Include(p => p.Unit)
        .Include(p => p.Supplier)
        .Include(p => p.Manufacturer)
        .Include(p => p.Category)
        .ToList();

        [ObservableProperty] string textFind;
        public List<Product> Sale => db.Products.ToList();

        public void BackAuth()
        {
            MainWindowViewModel.Instance.PageSwitcher = new AuthViewModel();
        }

        public void PriceSort(int sort)
        {
            switch (sort)
            {
                case 1:
                    Products = Products.OrderBy(x => x.Price).ToList();
                    break;
                case 2:
                    Products = Products.OrderByDescending(x => x.Price).ToList();
                    break;
            }
        }

        public void QuantityStock(int sort)
        {
            switch (sort)
            {
                case 1:
                    Products = Products.OrderBy(x => x.StockQuantity).ToList();
                    break;
                case 2:
                    Products = Products.OrderByDescending(x => x.StockQuantity).ToList();
                    break;
            }
        }

        partial void OnTextFindChanged(string value)
        {
            Products = Products0;
            Products = Products.Where(x =>
            x.ProductType.Name.Contains(value) ||
            x.Manufacturer.Name.Contains(value) ||
            x.Category.Name.Contains(value) ||
            x.Description.Contains(value)
            ).ToList();
        }

        partial void OnSelectedDiscountFilterChanged(int value)
        {
            Products = Products0;
            switch (value)
            {
                case 0:
                    Products = Products
                        .Where(x => x.CurrentDiscount >= 0 && x.CurrentDiscount <= 10.99)
                        .ToList();
                    break;

                case 1:
                    Products = Products
                        .Where(x => x.CurrentDiscount >= 11 && x.CurrentDiscount <= 14.99)
                        .ToList();
                    break;

                case 2:
                    Products = Products
                        .Where(x => x.CurrentDiscount >= 15)
                        .ToList();
                    break;
            }
        }

        public void CreateProduct()
        {
            MainWindowViewModel.Instance.PageSwitcher = new CreateViewModel();
        }



        [RelayCommand]
        public void Delete(Product product)
        {
            if (product == null)
                return;

            db.Products.Remove(product);
            db.SaveChanges();

            Products = db.Products
                .Include(p => p.ProductType)
                .Include(p => p.Unit)
                .Include(p => p.Supplier)
                .Include(p => p.Manufacturer)
                .Include(p => p.Category)
                .ToList();
        }
    }
}

