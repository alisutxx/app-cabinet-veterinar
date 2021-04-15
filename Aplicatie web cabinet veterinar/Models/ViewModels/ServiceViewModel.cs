using Aplicatie_web_cabinet_veterinar.Models.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicatie_web_cabinet_veterinar.Models.ViewModels
{
	public class ServiceViewModel
	{
		public ServiceModel Service { get; set; }
		public List<CategoryModel> Categories { get; set; }
	}
}