using System;
using System.ComponentModel.DataAnnotations;

namespace Service.ViewModels
{
	public class ForgotPasswordVM
	{
		public Dictionary<string, string>? SectionHeaders { get; set; }

		[Required, DataType(DataType.EmailAddress)]
		public string Email { get; set; }
	}
}