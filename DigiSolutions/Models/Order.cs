using System;
using System.Collections.Generic;

namespace DigiSolutions.Models;

public partial class Order
{
    public int Id { get; set; }

    public string? OrderNo { get; set; }

    public DateTime? CreateTime { get; set; }

    public int? Status { get; set; }

    public int? UserId { get; set; }

    public virtual Status? StatusNavigation { get; set; }

    public virtual User? User { get; set; }
}
