using System.Web;
using System.Web.Mvc;

namespace Aplicatie_web_cabinet_veterinar
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
