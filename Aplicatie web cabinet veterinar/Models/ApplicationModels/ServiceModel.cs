using System.ComponentModel.DataAnnotations;

namespace Aplicatie_web_cabinet_veterinar.Models.ApplicationModels
{
	public class ServiceModel
	{
		public int Id { get; set; }

		[Display(Name = "Nume")]
		[Required(ErrorMessage = "Numele este obligatoriu")]
		[MaxLength(53, ErrorMessage = "Lungimea maxima este 53 de caractere")]
		public string Name { get; set; }


		[Display(Name = "Descriere")]
		[Required(ErrorMessage = "Descrierea este obligatorie")]
		[MaxLength(255, ErrorMessage = "Lungimea maxima este 255 de caractere")]
		public string Description { get; set; }

		[Display(Name = "Pret")]
		[Required(ErrorMessage = "Pretul este obligatoriu")]
		public double Price { get; set; }

		[Display(Name = "Categorie")]
		[Required(ErrorMessage = "Categoria este obligatorie")]
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
	}
}