using System;
using System.Collections.Generic;

namespace app.Models;

public partial class Order
{
    public int Id { get; set; }

    public int OrderNumber { get; set; }

    public DateOnly? OrderDate { get; set; }

    public DateOnly? DeliveryDate { get; set; }

    public int PickupPointId { get; set; }

    public int? UserId { get; set; }

    public string ReceiveCode { get; set; } = null!;

    public int StatusId { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual PickupPoint PickupPoint { get; set; } = null!;

    public virtual OrderStatus Status { get; set; } = null!;

    public virtual User? User { get; set; }
}
