using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Aplicatie_web_cabinet_veterinar.Models.ApplicationModels
{
	public class AppointmentModel
	{
		public int Id { get; set; }

		[Display(Name = "Pret estimativ")]
		[Required(ErrorMessage = "Pretul estimativ este obligatoriu")]
		public double EstimativePrice { get; set; }
		public double? Price { get; set; }

		[Display(Name = "Data programarii")]
		[Required(ErrorMessage = "Data programarii este obligatorie")]
		public DateTime Date { get; set; }

		[Display(Name = "Animal de companie")]
		[Required(ErrorMessage = "Animalul de companie este obligatoriu este obligatorie")]
		public int PetId { get; set; }

		[Display(Name = "Numele animalului")]
		public string PetName { get; set; }

		[Display(Name = "Medic")]
		[Required(ErrorMessage = "Medicul este obligatoriu")]
		public int MedicId { get; set; }

		[Display(Name = "Numele medicului")]
		public string MedicName { get; set; }

		[Display(Name = "Emailul clientului")]
		public string ClientEmail { get; set; }

		public int ServiceId { get; set; }

		public string ServiceName { get; set; }

		public bool IsConfirmed { get; set; }
	}
}