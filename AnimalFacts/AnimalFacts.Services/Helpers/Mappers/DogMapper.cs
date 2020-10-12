using AnimalFacts.Domain.Entities;
using AnimalFacts.Presentation.Models;
using System.Collections.Generic;


namespace AnimalFacts.Services.Helpers.Mappers
{
    public static class DogMapper
    {        
        public static ResponseModel ToDogResponse(Dog dog)
        {
            return new ResponseModel
            {
                AddedOn = dog.AddedOn,
                Fact = dog.Fact,
                Source = dog.Source
            };
        }

        public static List<ResponseModel> ToDogResponse(List<Dog> dogs)
        {
            var dogRes = new List<ResponseModel>();
            dogs.ForEach(d =>
            {
                dogRes.Add(new ResponseModel
                {
                    AddedOn = d.AddedOn,
                    Fact = d.Fact,
                    Source = d.Source
                });
            });

            return dogRes;
        }

        public static Dog ToDog(RequestModel dogReq)
        {
            return new Dog
            {
                AddedOn = dogReq.AddedOn,
                Fact = dogReq.Fact,
                Source = dogReq.Source
            };
        }
    }
}