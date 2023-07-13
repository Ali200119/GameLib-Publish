using System;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Models
{
	public class Contact: BaseEntity
	{
		[Required, Display(Name = "Full Name")]
		public string FullName { get; set; }

		[Required, DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		public string Message { get; set; }
	}
}