using System.ComponentModel.DataAnnotations;

namespace Aplicatie_web_cabinet_veterinar.Models.DatabaseEntities
{
	public class Category
	{
		public int Id { get; set; }
		
		[Required]
		[MaxLength(127)]
		public string Name { get; set; }
	}
}