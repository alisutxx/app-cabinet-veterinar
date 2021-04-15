using System.ComponentModel.DataAnnotations;

namespace Aplicatie_web_cabinet_veterinar.Models.DatabaseEntities
{
	public class AppointmentService
	{
		public int Id { get; set; }

		[Required]
		public int AppointmentId { get; set; }
		public Appointment Appointment { get; set; }

		[Required]
		public int ServiceId { get; set; }
		public Service Service { get; set; }
	}
}
