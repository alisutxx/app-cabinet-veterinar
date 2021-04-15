using Aplicatie_web_cabinet_veterinar.Models.ApplicationModels;
using Aplicatie_web_cabinet_veterinar.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicatie_web_cabinet_veterinar.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _categoryRepo = new CategoryRepository(new Models.ApplicationDbContext());
        public CategoryController()
        {
        }
        public ActionResult Index()
        {
            return View(_categoryRepo.Get());
        }

        public ActionResult Show(int id)
		{
            CategoryModel category = _categoryRepo.Get(id);
            if (category == null)
                return HttpNotFound();

            return View(category);
		}

        public ActionResult Edit(int id)
		{
            CategoryModel category = _categoryRepo.Get(id);
            if (category == null)
                return HttpNotFound();

            return View("CategoryForm", category);
        }

        public ActionResult Add()
		{
            return View("CategoryForm", new CategoryModel());
		}

        [HttpGet]
        public ActionResult AddEdit(int? id)
        {
            CategoryModel category = new CategoryModel();

            if (id.GetValueOrDefault() != default)
                category = _categoryRepo.Get(id.GetValueOrDefault());
            
            if (category == null && id.GetValueOrDefault() != default)
                return HttpNotFound();
            else
                return View("CategoryForm", category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CategoryModel category)
		{
            if (!ModelState.IsValid)
                return View("CategoryForm", category);

			try
			{
                _categoryRepo.AddOrUpdate(category);
			}
            catch(Exception e)
			{
                return HttpNotFound();
			}
            if(category.Id == 0)
                return RedirectToAction("Index", "Category");

            return RedirectToAction("Show", new { id = category.Id });
		}
    }
}