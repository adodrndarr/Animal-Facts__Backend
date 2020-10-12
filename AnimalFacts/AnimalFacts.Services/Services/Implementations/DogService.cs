using AnimalFacts.DataAccess.Repositories;
using AnimalFacts.Domain.Entities;
using AnimalFacts.Presentation.Models;
using AnimalFacts.Services.Helpers.Mappers;
using AnimalFacts.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AnimalFacts.Services.Services.Implementations
{
    public class DogService : IDogService
    {
        private readonly IRepository<Dog> _dogRepo;
        public DogService(IRepository<Dog> dogRepo)
        {
            this._dogRepo = dogRepo;
        }


        public List<ResponseModel> GetAll()
        {
            var dogs = _dogRepo.GetAll().ToList();
            var dogResponses = DogMapper.ToDogResponse(dogs);

            return dogResponses;
        }
        
        public ResponseModel GetById(int id)
        {
            var dog = _dogRepo.GetById(id);
            var dogRes = DogMapper.ToDogResponse(dog);

            return dogRes;
        }

        public void AddDog(RequestModel dogReq)
        {
            var dog = DogMapper.ToDog(dogReq);
            dog.AddedOn = DateTime.Now;

            _dogRepo.Insert(dog);
        }

        public void UpdateDog(RequestModel dogReq, int id)
        {
            var dog = DogMapper.ToDog(dogReq);
            dog.Id = id;

            _dogRepo.Update(dog);
        }

        public void DeleteDog(int id) => _dogRepo.Delete(id);      
        
        public bool DogFactExists(int id)
        {
            var dog = _dogRepo.GetById(id);
            if (dog.Fact != null) return true;

            return false;
        }
    }
}