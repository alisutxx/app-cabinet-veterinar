using System;
using System.Security.Cryptography;
using System.Web;

namespace Aplicatie_web_cabinet_veterinar.Models.ApplicationModels
{
	public class ApplicationHelper
	{
		public enum Roles: int
		{
			Utilizator = 1,
			Angajat = 2,
			Manager = 3,
			Admin = 4
		}
		public static LoggedUser LoggedUser
		{ get 
			{ 
				return HttpContext.Current.Session["loggedUser"] as LoggedUser; 
			} 
		}

		public static bool IsAdmin
		{
			get
			{ 
				return LoggedUser != null && LoggedUser.RoleId == (int)Roles.Admin; 
			}
		}
		public static bool IsAngajat
		{
			get
			{ 
				return LoggedUser != null && LoggedUser.RoleId == (int)Roles.Angajat;
			}
		}

		public static bool IsUtilizator
		{
			get 
			{
				return LoggedUser != null && LoggedUser.RoleId == (int)Roles.Utilizator; 
			}
		}
		public static bool IsAdminOrAngajat
		{
			get
			{
				return IsAdmin || IsAngajat;
			}
		}
		public static bool IsAdminOrUtilizator
		{
			get
			{
				return IsAdmin || IsUtilizator;
			}
		}

		public static string EncryptPassword(string pass)
		{
			return Convert.ToBase64String(MD5.Create().ComputeHash(System.Text.UTF8Encoding.Default.GetBytes(pass)));
		}
	}
}