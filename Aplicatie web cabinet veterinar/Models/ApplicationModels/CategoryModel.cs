using System.ComponentModel.DataAnnotations;

namespace Aplicatie_web_cabinet_veterinar.Models.ApplicationModels
{
	public class CategoryModel
	{
		public int Id { get; set; }

		[Display(Name = "Categorie")]
		[Required(ErrorMessage = "Numele este obligatoriu.")]
		[MaxLength(127, ErrorMessage = "Lungimea maxima este 127 de caractere.")]
		public string Name { get; set; }
	}
}