using System;
using System.ComponentModel.DataAnnotations;

namespace Aplicatie_web_cabinet_veterinar.Models.ApplicationModels
{
	public class PetModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Numele este obligatoriu")]
		[MaxLength(63, ErrorMessage = "Lungimea maxima este 63 de caractere")]
		[Display(Name = "Nume")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Specia este obligatorie")]
		[MaxLength(63, ErrorMessage = "Lungimea maxima este 63 de caractere")]
		[Display(Name = "Specie")]

		public string Species { get; set; }

		[MaxLength(63, ErrorMessage = "Lungimea maxima este 63 de caractere")]
		[Display(Name = "Rasa")]

		public string Breed { get; set; }

		[Required(ErrorMessage = "Data de nastere este obligatorie")]
		[Display(Name = "Data de nastere")]

		//Custom for birthdate to not be in the future
		public DateTime BirthDate { get; set; }
		public int OwnerId { get; set; }

		[Display(Name = "Stapan")]

		public string OwnerName { get; set; }
	}
}