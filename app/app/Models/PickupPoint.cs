using System;
using System.Collections.Generic;

namespace app.Models;

public partial class PickupPoint
{
    public int Id { get; set; }

    public string PostalCode { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string? House { get; set; }

    public string FullAddress { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
