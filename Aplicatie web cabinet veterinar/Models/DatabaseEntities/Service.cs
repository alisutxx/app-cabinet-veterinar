using System.ComponentModel.DataAnnotations;

namespace Aplicatie_web_cabinet_veterinar.Models.DatabaseEntities
{
	public class Service
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(53)]
		public string Name { get; set; }

		[Required]
		[MaxLength(255)]
		public string Description { get; set; }

		[Required]
		public double Price { get; set; }

		[Required]
		public int CategoryId { get; set; }
		public Category Category { get; set; }
	}
}
