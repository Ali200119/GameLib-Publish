using System;
namespace Domain.Common
{
	public abstract class BaseEntity
	{
		public int Id { get; set; }
		public bool SoftDelete { get; set; } = false;
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public DateTime ModifiedAt { get; set; } = DateTime.Now;
	}
}