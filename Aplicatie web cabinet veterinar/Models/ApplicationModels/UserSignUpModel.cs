using Aplicatie_web_cabinet_veterinar.Models.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace Aplicatie_web_cabinet_veterinar.Models.ApplicationModels
{
	public class UserSignUpModel
	{
		public UserSignUpModel()
		{
		}

		public UserSignUpModel(UserSignUpModel model)
		{
			Id = model.Id;
			FirstName = model.FirstName;
			LastName = model.LastName;
			Email = model.Email;
			PhoneNumber = model.PhoneNumber;
			Password = model.Password;
		}

		public int Id { get; set; }

		[MaxLength(63, ErrorMessage = "Lungimea maxima este 63 de caractere")]
		[Display(Name = "Prenume")]
		[Required(ErrorMessage = "Prenumele este obligatoriu")]
		public string FirstName { get; set; }

		[Display(Name = "Nume")]
		[Required(ErrorMessage = "Numele este obligatoriu")]
		[MaxLength(31, ErrorMessage = "Lungimea maxima este 31 de caractere")]
		public string LastName { get; set; }
		
		[Display(Name = "Email")]
		[Required(ErrorMessage = "Adresa de email este obligatorie")]
		[MaxLength(255, ErrorMessage = "Lungimea maxima este 255 de caractere")]
		[EmailAddress(ErrorMessage = "Introduceti o adresa de email valida.")]
		public string Email { get; set; }

		[Display(Name = "Numar de telefon")]
		[Required(ErrorMessage = "Numarul de telefon este obligatoriu")]
		[MaxLength(31, ErrorMessage = "Lungimea maxima este 31 de caractere")]
		public string PhoneNumber { get; set; }

		[Display(Name = "Parola")]
		[Required(ErrorMessage = "Parola este obligatorie")]
		[SamePassword]
		[MaxLength(255, ErrorMessage = "Lungimea maxima este 255 de caractere")]
		public string Password { get; set; }
		[Display(Name = "Confirma Parola")]
		[Required(ErrorMessage = "Parola este obligatorie")]
		[SamePassword]
		[MaxLength(255, ErrorMessage = "Lungimea maxima este 255 de caractere")]
		public string ConfirmPassword { get; set; }
	}
}