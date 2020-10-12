using AnimalFacts.Domain.Entities;
using AnimalFacts.Presentation.Models;
using System.Collections.Generic;


namespace AnimalFacts.Services.Helpers.Mappers
{
    public static class RabbitMapper
    {
        public static ResponseModel ToRabbitResponse(Rabbit rabbit)
        {
            return new ResponseModel
            {
                AddedOn = rabbit.AddedOn,
                Fact = rabbit.Fact,
                Source = rabbit.Source
            };
        }

        public static List<ResponseModel> ToRabbitResponse(List<Rabbit> rabbits)
        {
            var rabbitRes = new List<ResponseModel>();
            rabbits.ForEach(r =>
            {
                rabbitRes.Add(new ResponseModel
                {
                    AddedOn = r.AddedOn,
                    Fact = r.Fact,
                    Source = r.Source
                });
            });

            return rabbitRes;
        }

        public static Rabbit ToRabbit(RequestModel rabbitReq)
        {
            return new Rabbit
            {
                AddedOn = rabbitReq.AddedOn,
                Fact = rabbitReq.Fact,
                Source = rabbitReq.Source
            };
        }
    }
}