using System.ComponentModel.DataAnnotations;

namespace Aplicatie_web_cabinet_veterinar.Models.ApplicationModels
{
	public class UserModel: UserSignUpModel
	{
		public UserModel()
		{

		}
		public UserModel(UserSignUpModel model) : base(model)
		{
		}

		[Display(Name = "Specializare")]
		[MaxLength(63, ErrorMessage = "Lungimea maxima este 63 de caractere")]
		public string Specialization { get; set; }

		public bool IsDeleted { get; set; }
		public int RoleId { get; set; }
	}
}