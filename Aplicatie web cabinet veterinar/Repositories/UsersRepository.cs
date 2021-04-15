using Aplicatie_web_cabinet_veterinar.Models;
using Aplicatie_web_cabinet_veterinar.Models.ApplicationModels;
using Aplicatie_web_cabinet_veterinar.Models.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using static Aplicatie_web_cabinet_veterinar.Models.ApplicationModels.ApplicationHelper;

namespace Aplicatie_web_cabinet_veterinar.Repositories
{
	public class UsersRepository
	{
		private readonly ApplicationDbContext _db;
		public UsersRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public List<MedicModel> GetMedicsForAppointment()
		{
			return _db.Users
				.Where(u => u.Specialization != null && u.Specialization != "" && u.RoleId == (int)Roles.Angajat)
				.Select(m => new MedicModel 
					{ 
						Id = m.Id,
						FirstName = m.FirstName,
						LastName = m.LastName,
						Specialization = m.Specialization
					})
				.ToList();
		}

		public void DeleteUser(int id)
		{
			var user = _db.Users.Where(u => u.Id == id).FirstOrDefault();
			if (user == null)
				throw new Exception();

			user.IsDeleted = true;
			_db.SaveChanges();
			
		}

		public bool Authenticate(UserAuthenticationModel model)
		{
			var userInDb = _db.Users.Include(u => u.Role).Where(u => u.Email == model.Email).FirstOrDefault();
			if (userInDb != null && EncryptPassword(model.Password) == userInDb.Password)
			{
				if (userInDb.IsDeleted)
				{
					userInDb.IsDeleted = false;
					_db.SaveChanges();
				}
				HttpContext.Current.Session.Add("LoggedUser", new LoggedUser()
				{
					Id = userInDb.Id,
					Email = userInDb.Email,
					Name = string.Concat(userInDb.LastName, " ", userInDb.FirstName),
					RoleId = userInDb.RoleId
				});
				return true;
			}
			return false;
		}

		public void SaveSignUpUser(UserSignUpModel model)
		{
			var pas = EncryptPassword(model.Password);
			_db.Users.Add(new User
			{
				IsDeleted = false,
				Email = model.Email,
				FirstName = model.FirstName,
				LastName = model.LastName,
				Password = pas,
				PhoneNumber = model.PhoneNumber,
				RoleId = (int)Roles.Utilizator
			});
			_db.SaveChanges();
		}

		public void RegisterNewEmployee(UserModel model)
		{
			var pas = EncryptPassword(model.Password);

			if (IsAdmin)
			{
				_db.Users.Add(new User
				{
					IsDeleted = false,
					Email = model.Email,
					FirstName = model.FirstName,
					LastName = model.LastName,
					Password = pas,
					PhoneNumber = model.PhoneNumber,
					Specialization = model.Specialization,
					RoleId = (int)Roles.Angajat

				});
				_db.SaveChanges();
			}	
		}
	}
}