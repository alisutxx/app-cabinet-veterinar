using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Aplicatie_web_cabinet_veterinar.Models.DatabaseEntities
{
	public class Appointment
	{
		public int Id { get; set; }

		[Required]
		public double EstimativePrice { get; set; }

		public double? Price { get; set; }

		[Required]
		public DateTime Date { get; set; }

		[Required]
		public int PetId { get; set; }
		public Pet Pet { get; set; }

		[Required]
		public int MedicId { get; set; }
		public User Medic { get; set; }

		[DefaultValue(true)]
		public bool IsConfirmed { get; set; }
	}
}
