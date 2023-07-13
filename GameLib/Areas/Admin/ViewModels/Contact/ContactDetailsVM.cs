using System;
using System.ComponentModel.DataAnnotations;

namespace GameLib.Areas.Admin.ViewModels.Contact
{
	public class ContactDetailsVM
	{
		public string Email { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }
		public string Message { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}