using System;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Models
{
	public class BlogComment: BaseEntity
	{
		[Required]
		public string Comment { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}