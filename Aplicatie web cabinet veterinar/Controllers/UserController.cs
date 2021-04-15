using Aplicatie_web_cabinet_veterinar.Models;
using Aplicatie_web_cabinet_veterinar.Models.ApplicationModels;
using Aplicatie_web_cabinet_veterinar.Models.CustomValidation;
using Aplicatie_web_cabinet_veterinar.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Aplicatie_web_cabinet_veterinar.Models.ApplicationModels.ApplicationHelper;

namespace Aplicatie_web_cabinet_veterinar.Controllers
{
    public class UserController : Controller
    {
        private readonly UsersRepository _usersRepo = new UsersRepository(new Models.ApplicationDbContext());
		public UserController()
		{
		}
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult ShowMedics()
		{
			var medicsList = _usersRepo.GetMedicsForAppointment();
			return View(medicsList);
		}

        [HttpGet]
        public ActionResult Authenticate()
        {
            if (ApplicationHelper.LoggedUser != null)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new UserAuthenticationModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       // [ValidateAccountStatus]
        public ActionResult Authenticate(UserAuthenticationModel model)
        {
            if (_usersRepo.Authenticate(model))
                return RedirectToAction("Index", "Home");

            ViewBag.Message = "Email si / sau parola incorecte.";
            return View();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            if (ApplicationHelper.LoggedUser != null)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new UserSignUpModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(UserSignUpModel model)
        {
            if(!ModelState.IsValid)
			{
                return View(model);
            }
			else
			{
                _usersRepo.SaveSignUpUser(model);
                //autentifica userul
                this.Authenticate(new UserAuthenticationModel { Email = model.Email, Password = model.Password });
                return RedirectToAction("Index", "Home");
            }
            
        }

        public ActionResult LogOut()
        {
            Session["LoggedUser"] = null;
            return RedirectToAction("Index", "Home");
        }

        [@Authorize]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                if (ApplicationHelper.LoggedUser.Id == id && IsUtilizator)
                {
                    _usersRepo.DeleteUser(id);
                    Session["LoggedUser"] = null;
                    return RedirectToAction("Index", " Home");
                }

                if (IsAdmin)
                {
                    _usersRepo.DeleteUser(id);
                    return View("List");
                }
                throw new Exception();
            }
            catch
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        [AuthorizeAdminRole]
        public ActionResult RegisterNewEmployee()
        {
            var model = new UserModel();
            return View(model);
        }

        [HttpPost]
        [AuthorizeAdminRole]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterNewEmployee(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                _usersRepo.RegisterNewEmployee(model);
                return RedirectToAction("ShowMedics");
            }
        }
    }
}