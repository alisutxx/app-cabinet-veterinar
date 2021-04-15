using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicatie_web_cabinet_veterinar.Models.ApplicationModels
{
	public class LoggedUser
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Name { get; set; }
		public int RoleId { get; set; }
	}
}