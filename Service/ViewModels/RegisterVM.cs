using System;
using System.ComponentModel.DataAnnotations;

namespace Service.ViewModels
{
	public class RegisterVM
	{
		public Dictionary<string, string>? SectionHeaders { get; set; }

		[Required, Display(Name = "Full Name")]
		public string FullName { get; set; }

		[Required, DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		public string Username { get; set; }

		[Required, DataType(DataType.Password)]
		public string Password { get; set; }

        [Required, DataType(DataType.Password)]
		[Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}