using System;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
	public class AppUser: IdentityUser
	{
		public string FullName { get; set; }
		public ICollection<GameComment> GameComments { get; set; }
		public ICollection<BlogComment> BlogComments { get; set; }
    }
}