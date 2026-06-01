using System;
using System.Collections.Generic;

namespace app.Models;

public partial class Product
{
    public string Article { get; set; } = null!;

    public int ProductTypeId { get; set; }

    public int UnitId { get; set; }

    public int SupplierId { get; set; }

    public int ManufacturerId { get; set; }

    public int CategoryId { get; set; }

    public decimal Price { get; set; }

    public int CurrentDiscount { get; set; }

    public int StockQuantity { get; set; }

    public string? Description { get; set; }

    public string? Photo { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ProductType ProductType { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;

    public virtual Unit Unit { get; set; } = null!;
}
