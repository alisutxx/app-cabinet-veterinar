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
    public class ServiceController : Controller
    {
        private readonly CategoryRepository _categoryRepo = new CategoryRepository(new Models.ApplicationDbContext());
        private readonly ServiceRepository _serviceRepo = new ServiceRepository(new Models.ApplicationDbContext());
        public ServiceController()
        {
        }
        public ActionResult Index()
        {
            return View(_categoryRepo.Get());
        }

        public ActionResult Show(int id)
        {
            ServiceModel service = _serviceRepo.Get(id);
            if (service == null)
                return HttpNotFound();

            return View(service);
        }


        [HttpGet]
        public ActionResult AddEdit(int? id)
        {
            var model = new ServiceViewModel()
            {
                Categories = _categoryRepo.Get(),
                Service = new ServiceModel()
            };

            if (id.GetValueOrDefault() != default)
                model.Service = _serviceRepo.Get(id.GetValueOrDefault());

            if (model.Service == null && id.GetValueOrDefault() != default)
                return HttpNotFound();
            else
                return View("ServiceForm", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ServiceModel service)
        {
            if (!ModelState.IsValid)
			{
                ServiceViewModel model = new ServiceViewModel()
                {
                    Service = service,
                    Categories = _categoryRepo.Get()
                };

                return View("ServiceForm", model);
			}

            try
            {
                _serviceRepo.AddOrUpdate(service);
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }

            if (service.Id == 0)
                return RedirectToAction("Index", "Service");

            return RedirectToAction("Show", new { id = service.Id });
        }


        public ActionResult ShowServicesByCategoryId(int id)
		{
            var services = _serviceRepo.GetServicesByCategoryId(id);

            return View(services);
		}
    }
}