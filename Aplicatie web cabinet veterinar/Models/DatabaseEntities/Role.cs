using System.ComponentModel.DataAnnotations;

namespace Aplicatie_web_cabinet_veterinar.Models.DatabaseEntities
{
	public class Role
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(31)]
		public string Name { get; set; }
	}
}