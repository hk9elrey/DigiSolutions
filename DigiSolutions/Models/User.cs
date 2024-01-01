using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiSolutions.Models;

public partial class User
{
	[Required]

	public int Id { get; set; }
	[Required]

	public string? Name { get; set; }

	[Required]
	public string? Email { get; set; }
	public string? Password { get; set; }

	[NotMapped]
	[Compare(nameof(Password),ErrorMessage = "Re entered password doesn't match")]
	public string? ReenterPassword { get; set; }

	[Required]

	public string? Phone { get; set; }
	[Required]

	public string? Address { get; set; }

	public int? Role { get; set; }

	public virtual ICollection<Cart>? Carts { get; set; } = new List<Cart>();

	public virtual ICollection<Order>? Orders { get; set; } = new List<Order>();

	public virtual Role? RoleNavigation { get; set; }
}
