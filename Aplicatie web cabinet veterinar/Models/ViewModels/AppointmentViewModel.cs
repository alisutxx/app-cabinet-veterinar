using Aplicatie_web_cabinet_veterinar.Models.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicatie_web_cabinet_veterinar.Models.ViewModels
{
	public class AppointmentViewModel
	{
		public AppointmentModel Appointment { get; set; }

		public List<PetModel> Pets { get; set; }

		public List<MedicModel> Medics { get; set; }

		public List<ServiceModel> Services { get; set; }
	}
}