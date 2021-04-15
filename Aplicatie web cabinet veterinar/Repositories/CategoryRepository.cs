using Aplicatie_web_cabinet_veterinar.Models;
using Aplicatie_web_cabinet_veterinar.Models.ApplicationModels;
using Aplicatie_web_cabinet_veterinar.Models.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicatie_web_cabinet_veterinar.Repositories
{
	public class CategoryRepository
	{
		private readonly ApplicationDbContext _db;
		public CategoryRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public List<CategoryModel> Get()
		{
			return _db.Categories
				.Select(b => new CategoryModel() { Id = b.Id, Name = b.Name })
				.ToList();
		}
		public CategoryModel Get(int id)
		{
			return _db.Categories
				.Select(b => new CategoryModel() { Id = b.Id, Name = b.Name})
				.SingleOrDefault(b => b.Id == id);
		}

		public void Delete(int id)
		{
			Category dbCategory = _db.Categories.SingleOrDefault(a => a.Id == id);
			if (dbCategory == null)
				throw new Exception();

			_db.Categories.Remove(dbCategory);
			_db.SaveChanges();
		}

		public CategoryModel AddOrUpdate(CategoryModel category)
		{
			if(category.Id == 0)
			{
				_db.Categories.Add(new Category() { Name = category.Name });
			}
			else
			{
				Category dbCategory = _db.Categories.SingleOrDefault(cat => cat.Id == category.Id);
				if (dbCategory == null)
					throw new Exception();
				dbCategory.Name = category.Name;
			}

			_db.SaveChanges();
			return category;
		}
	}
}