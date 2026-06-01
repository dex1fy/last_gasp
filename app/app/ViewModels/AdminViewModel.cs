using app.Models;
using CommunityToolkit.Mvvm.ComponentModel;
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
        [ObservableProperty] List<Product> products = db.Products
        .Include(p => p.ProductType)
        .Include(p => p.Unit)
        .Include(p => p.Supplier)
        .Include(p => p.Manufacturer)
        .Include(p => p.Category)
        .ToList();

    }
}
