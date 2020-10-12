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
    public class CatService : ICatService
    {
        private readonly IRepository<Cat> _catRepo;
        public CatService(IRepository<Cat> catRepo)
        {
            this._catRepo = catRepo;
        }


        public List<ResponseModel> GetAll()
        {
            var cats = _catRepo.GetAll().ToList();
            var catResponses = CatMapper.ToCatResponse(cats);

            return catResponses;
        }

        public ResponseModel GetById(int id)
        {
            var cat = _catRepo.GetById(id);
            var catRes = CatMapper.ToCatResponse(cat);

            return catRes;
        }

        public void AddCat(RequestModel catReq)
        {
            var cat = CatMapper.ToCat(catReq);
            cat.AddedOn = DateTime.Now;

            _catRepo.Insert(cat);
        }

        public void UpdateCat(RequestModel catReq, int id)
        {
            var cat = CatMapper.ToCat(catReq);
            cat.Id = id;

            _catRepo.Update(cat);
        }

        public void DeleteCat(int id) => _catRepo.Delete(id);

        public bool CatFactExists(int id)
        {
            var cat = _catRepo.GetById(id);
            if (cat != null) return true;

            return false;
        }
    }
}