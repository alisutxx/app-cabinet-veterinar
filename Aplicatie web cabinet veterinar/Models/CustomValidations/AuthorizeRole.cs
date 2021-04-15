using Aplicatie_web_cabinet_veterinar.Models.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using static Aplicatie_web_cabinet_veterinar.Models.ApplicationModels.ApplicationHelper;

namespace Aplicatie_web_cabinet_veterinar.Models.CustomValidation
{
	public class AuthorizeAdminRole : FilterAttribute, IAuthorizationFilter
	{
		public AuthorizeAdminRole()
		{

		}
		public void OnAuthorization(AuthorizationContext filterContext)
		{
			if (!IsAdmin)
			{
				filterContext.Result = new RedirectToRouteResult
					(new RouteValueDictionary
					{
						{ "controller", "Home"},
						{ "action", "UnAuthorized"}
					});
			}
		}


	}
	public class AuthorizeEmployeeRole : FilterAttribute, IAuthorizationFilter
	{
		public AuthorizeEmployeeRole()
		{

		}
		public void OnAuthorization(AuthorizationContext filterContext)
		{
			if (!IsAdminOrAngajat)
			{
				filterContext.Result = new RedirectToRouteResult
					(new RouteValueDictionary
					{
						{ "controller", "Home"},
						{ "action", "UnAuthorized"}
					});
			}
		}


	}
	public class AuthorizeUserRole : FilterAttribute, IAuthorizationFilter
	{
		public AuthorizeUserRole()
		{

		}
		public void OnAuthorization(AuthorizationContext filterContext)
		{
			if (!IsAdminOrUtilizator)
			{
				filterContext.Result = new RedirectToRouteResult
					(new RouteValueDictionary
					{
						{ "controller", "Home"},
						{ "action", "UnAuthorized"}
					});
			}
		}
	}

	public class Authorize : FilterAttribute, IAuthorizationFilter
	{
		public Authorize()
		{

		}
		public void OnAuthorization(AuthorizationContext filterContext)
		{
			if (ApplicationHelper.LoggedUser == null)
			{
				filterContext.Result = new RedirectToRouteResult
					(new RouteValueDictionary
					{
						{ "controller", "Home"},
						{ "action", "UnAuthorized"}
					});
			}
		}
	}

}