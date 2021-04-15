using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aplicatie_web_cabinet_veterinar.Models.DatabaseEntities
{
	public class Test
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
	}
}