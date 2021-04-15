namespace Aplicatie_web_cabinet_veterinar.Models.ApplicationModels
{
	public class MedicModel
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Specialization { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }

		public string FullName { get { return this.LastName + " " + this.FirstName; } }
	}
}