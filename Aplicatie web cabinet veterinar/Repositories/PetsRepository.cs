using Aplicatie_web_cabinet_veterinar.Models;
using Aplicatie_web_cabinet_veterinar.Models.ApplicationModels;
using Aplicatie_web_cabinet_veterinar.Models.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Aplicatie_web_cabinet_veterinar.Repositories
{
	public class PetsRepository
	{
		private readonly ApplicationDbContext _db;
		public PetsRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public List<PetModel> GetPetsByOwner(int ownerId)
		{
			return _db.Pets
				.Include(p => p.Owner)
				.Where(p => p.OwnerId == ownerId)
				.Select(p => new PetModel ()
				{ 
					Id = p.Id,
					BirthDate = p.BirthDate,
					Breed = p.Breed,
					Name = p.Name,
					OwnerId = p.OwnerId,
					OwnerName = p.Owner.FirstName + p.Owner.LastName,
					Species = p.Species
				})
				.ToList();
		}
		public List<PetModel> GetPets(int pageNo, int pageSize)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			var petinDb = _db.Pets.SingleOrDefault(predicate => predicate.Id == id);
			if (petinDb == null)
				throw new Exception(message: $"Animalul cu idul {id} nu exista");

			petinDb.IsDeleted = true;
			_db.SaveChanges();
		}

		public PetModel Get(int id)
		{
			Pet petInDb = _db.Pets.Include(p => p.Owner).SingleOrDefault(p => p.Id == id);
			return petInDb == null ? null : new PetModel()
			{
				BirthDate = petInDb.BirthDate,
				Breed = petInDb.Breed,
				Id = petInDb.Id,
				Name = petInDb.Name,
				OwnerId = petInDb.OwnerId,
				Species = petInDb.Species,
				OwnerName = petInDb.Owner.LastName + petInDb.Owner.FirstName
			};
		}

		public PetModel AddOrUpdate(PetModel pet)
		{
			if(pet.Id == 0)
			{
				_db.Pets.Add(new Pet (){
					Breed = pet.Breed,
					BirthDate = pet.BirthDate,
					IsDeleted = false,
					Name = pet.Name,
					OwnerId = pet.OwnerId,
					Species = pet.Species
				});
			}
			else
			{
				var dbPet = _db.Pets.SingleOrDefault(p => p.Id == pet.Id);
				if (dbPet == null)
					throw new Exception();
				dbPet.Breed = pet.Breed;
				dbPet.BirthDate = pet.BirthDate;
				dbPet.Name = pet.Name;
				dbPet.OwnerId = pet.OwnerId;
				dbPet.Species = pet.Species;
			}
			_db.SaveChanges();

			return pet;
		}
	}
}