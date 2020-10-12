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
    public class RabbitService : IRabbitService
    {
        private readonly IRepository<Rabbit> _rabbitRepo;
        public RabbitService(IRepository<Rabbit> rabbitRepo)
        {
            this._rabbitRepo = rabbitRepo;
        }


        public List<ResponseModel> GetAll()
        {
            var rabbits = _rabbitRepo.GetAll().ToList();
            var rabbitResponses = RabbitMapper.ToRabbitResponse(rabbits);

            return rabbitResponses;
        }

        public ResponseModel GetById(int id)
        {
            var rabbit = _rabbitRepo.GetById(id);
            var rabbitRes = RabbitMapper.ToRabbitResponse(rabbit);

            return rabbitRes;
        }

        public void AddRabbit(RequestModel rabbitReq)
        {
            var rabbit = RabbitMapper.ToRabbit(rabbitReq);
            rabbit.AddedOn = DateTime.Now;

            _rabbitRepo.Insert(rabbit);
            _rabbitRepo.SaveChanges();
        }

        public void UpdateRabbit(RequestModel rabbitReq, int id)
        {
            var rabbit = RabbitMapper.ToRabbit(rabbitReq);
            rabbit.Id = id;

            _rabbitRepo.Update(rabbit);
            _rabbitRepo.SaveChanges();
        }

        public void DeleteRabbit(int id)
        {
            _rabbitRepo.Delete(id);
            _rabbitRepo.SaveChanges();
        }

        public bool RabbitFactExists(int id)
        {
            var rabbit = _rabbitRepo.GetById(id);
            if (rabbit != null) return true;

            return false;
        }
    }
}