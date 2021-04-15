using System.ComponentModel.DataAnnotations;


namespace Aplicatie_web_cabinet_veterinar.Models.DatabaseEntities
{
	public class User
	{
		public int Id { get; set; }

		[MaxLength(63)]
		[Required]
		public string FirstName { get; set; }

		[Required]
		[MaxLength(31)]
		public string LastName { get; set; }

		[Required]
		[MaxLength(255)]
		public string Email { get; set; }

		[Required]
		[MaxLength(255)]
		public string Password { get; set; }

		[Required]
		[MaxLength(31)]
		public string PhoneNumber { get; set; }

		[MaxLength(63)]
		public string Specialization { get; set; }

		public bool IsDeleted { get; set; }

		[Required]
		public int RoleId { get; set; }
		public Role Role { get; set; }

	}
}
