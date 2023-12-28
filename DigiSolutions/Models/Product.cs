﻿using System;
using System.Collections.Generic;

namespace DigiSolutions.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public double? Price { get; set; }

    public int? Stock { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public int? CategoryId { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category? Category { get; set; }
}
