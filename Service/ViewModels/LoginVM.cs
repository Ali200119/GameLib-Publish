using System;
using System.ComponentModel.DataAnnotations;

namespace Service.ViewModels
{
	public class LoginVM
	{
		public Dictionary<string, string>? SectionHeaders { get; set; }

		[Required]
		public string UsernameOrEmail { get; set; }

		[Required, DataType(DataType.Password)]
		public string Password { get; set; }
	}
}