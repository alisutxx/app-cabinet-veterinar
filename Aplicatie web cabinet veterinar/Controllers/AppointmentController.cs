using Aplicatie_web_cabinet_veterinar.Models.ApplicationModels;
using Aplicatie_web_cabinet_veterinar.Models.ViewModels;
using Aplicatie_web_cabinet_veterinar.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicatie_web_cabinet_veterinar.Controllers
{
    public class AppointmentController : Controller
    {
		private readonly AppointmentsRepository _appointmentsRepo = new AppointmentsRepository(new Models.ApplicationDbContext());
        private readonly UsersRepository _usersRepo = new UsersRepository(new Models.ApplicationDbContext());
        private readonly PetsRepository _petsRepo = new PetsRepository(new Models.ApplicationDbContext());
        private readonly ServiceRepository _servRepo = new ServiceRepository(new Models.ApplicationDbContext());
        public AppointmentController()
		{
		}
        public ActionResult Index()
        {
			try
			{
                return View(_appointmentsRepo.GetAppointments(ApplicationHelper.LoggedUser.Id, ApplicationHelper.LoggedUser.RoleId));
			}
            catch(Exception e)
			{
                return HttpNotFound();
			}
        }


        public ActionResult Show(int id)
        {
            AppointmentModel appointment = _appointmentsRepo.Get(id);
            if (appointment == null)
                return HttpNotFound();

            return View(appointment);
        }

        public ActionResult AddForClient(int serviceId, double price, string serviceName)
		{
            var model = new AppointmentViewModel()
            {
                Appointment = new AppointmentModel { ServiceId = serviceId, EstimativePrice = price, ServiceName = serviceName },
                Medics = _usersRepo.GetMedicsForAppointment(),
                Pets = _petsRepo.GetPetsByOwner(ApplicationHelper.LoggedUser.Id)
            };

            return View(model);
        }


        [HttpGet]
        public ActionResult AddEdit(int serviceId, int? id)
        {
            var model = new AppointmentViewModel()
            {
                Appointment = new AppointmentModel { ServiceId = serviceId},
                Medics = _usersRepo.GetMedicsForAppointment(),
                Pets = _petsRepo.GetPetsByOwner(ApplicationHelper.LoggedUser.Id)
            };
            if (id.GetValueOrDefault() != default)
               model.Appointment = _appointmentsRepo.Get(id.GetValueOrDefault());


            return View("AppointmentForm", model);
        }
        [HttpPost]
        public ActionResult Save(AppointmentModel appointment)
        {
            if(!ModelState.IsValid)
			{
                return View("AppointmentForm", new AppointmentViewModel()
                {
                    Appointment = appointment,
                    Medics = _usersRepo.GetMedicsForAppointment(),
                    Pets = _petsRepo.GetPetsByOwner(ApplicationHelper.LoggedUser.Id)
                });
			}
			try
			{
                _appointmentsRepo.AddOrUpdate(appointment);
            }
            catch (Exception e)
			{
                return HttpNotFound();
			}


            if (appointment.Id == 0)
                return RedirectToAction("Index", "Appointment");

            return RedirectToAction("Show", new { id = appointment.Id});
        }

        [HttpPost]
        public ActionResult SaveAddForClient(AppointmentModel appointment)
		{
            if (!ModelState.IsValid)
            {
                return View("AppointmentForm", new AppointmentViewModel()
                {
                    Appointment = appointment,
                    Medics = _usersRepo.GetMedicsForAppointment(),
                    Pets = _petsRepo.GetPetsByOwner(ApplicationHelper.LoggedUser.Id)
                });
            }
            try
            {
                _appointmentsRepo.AddOrUpdate(appointment);
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
           throw new NotImplementedException();
        }


        //Doar angajati sau admini
        public ActionResult ConfirmAppointment(int id)
		{
			try
			{
                _appointmentsRepo.ConfirmAppointment(id);
			}
            catch(Exception e)
			{
                return HttpNotFound();
			}

            return RedirectToAction("Index");
		}
    }
}