using System;
using System.Collections.Generic;

namespace app.Models;

public partial class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public string ProductArticle { get; set; } = null!;

    public int Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product ProductArticleNavigation { get; set; } = null!;
}
