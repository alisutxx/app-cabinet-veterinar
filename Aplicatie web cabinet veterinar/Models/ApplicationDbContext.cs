using Aplicatie_web_cabinet_veterinar.Models.DatabaseEntities;
using System.Data.Entity;

namespace Aplicatie_web_cabinet_veterinar.Models
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext() :base("DefaultConnection")
		{

		}

		public DbSet<Appointment> Appointments { get; set; }
		public DbSet<AppointmentService> AppointmentServices { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Pet> Pets { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
