using System;
using System.ComponentModel.DataAnnotations;

namespace Aplicatie_web_cabinet_veterinar.Models.DatabaseEntities
{
	public class Pet
	{
		public int Id  { get; set; }
		
		[Required]
		[MaxLength(63)]
		public string Name { get; set; }

		[Required]
		[MaxLength(63)]
		public string Species { get; set; }

		[MaxLength(63)]
		public string Breed { get; set; }

		[Required]
		public DateTime BirthDate { get; set; }

		[Required]
		public int OwnerId { get; set; }
		public User Owner { get; set; }

		public bool IsDeleted { get; set; }
	}
}
