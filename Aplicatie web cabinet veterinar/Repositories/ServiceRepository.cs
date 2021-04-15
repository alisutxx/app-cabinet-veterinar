using Aplicatie_web_cabinet_veterinar.Models;
using Aplicatie_web_cabinet_veterinar.Models.ApplicationModels;
using Aplicatie_web_cabinet_veterinar.Models.DatabaseEntities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;

namespace Aplicatie_web_cabinet_veterinar.Repositories
{
	public class ServiceRepository
	{
		private readonly ApplicationDbContext _db;
		public ServiceRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public List<ServiceModel> Get()
		{
			return _db.Services
				.Include(b => b.Category)
				.Select(b => new ServiceModel()
				{ 
					Id = b.Id,
					Name = b.Name,
					Description = b.Description,
					CategoryName = b.Category.Name,
					CategoryId = b.CategoryId,
					Price = b.Price
				})
				.ToList();
		}

		public List<ServiceModel> GetByCategoryId(int categoryId)
		{
			return _db.Services
				.Include(b => b.Category)
				.Where(serv => serv.CategoryId == categoryId)
				.Select(b => new ServiceModel()
				{
					Id = b.Id,
					Name = b.Name,
					Description = b.Description,
					CategoryName = b.Category.Name,
					CategoryId = b.CategoryId,
					Price = b.Price
				})
				.ToList();
		}
		public ServiceModel Get(int id)
		{
			return _db.Services
				.Include(b => b.Category)
				.Select(b => new ServiceModel()
				{
					Id = b.Id,
					Name = b.Name,
					Description = b.Description,
					CategoryName = b.Category.Name,
					CategoryId = b.CategoryId,
					Price = b.Price
				})
				.SingleOrDefault(b => b.Id == id);
		}

		public void Delete(int id)
		{
			Service dbService = _db.Services.SingleOrDefault(a => a.Id == id);
			if (dbService == null)
				throw new Exception();

			_db.Services.Remove(dbService);
			_db.SaveChanges();
		}

		public ServiceModel AddOrUpdate(ServiceModel service)
		{
			if (service.Id == 0)
			{
				_db.Services.Add(new Service()
				{
					Name = service.Name,
					CategoryId = service.CategoryId,
					Description = service.Description,
					Price = service.Price
				});
			}
			else
			{
				Service dbService = _db.Services.SingleOrDefault(cat => cat.Id == service.Id);
				if (dbService == null)
					throw new Exception();
				dbService.Name = service.Name;
				dbService.CategoryId = service.CategoryId;
				dbService.Description = service.Description;
				dbService.Price = service.Price;
			}

			_db.SaveChanges();
			return service;
		}


		public List<ServiceModel> GetServicesByCategoryId(int id)
		{
			return _db.Services
				.Where(serv => serv.CategoryId == id)
				.Select(serv => new ServiceModel 
				{ 
					 Id = serv.Id,
					 CategoryId = serv.CategoryId,
					 Name = serv.Name,
					 Price = serv.Price
				})
				.ToList();
		}
	}
}