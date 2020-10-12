using AnimalFacts.Domain.Entities;
using AnimalFacts.Presentation.Models;
using System.Collections.Generic;


namespace AnimalFacts.Services.Helpers.Mappers
{
    public class CatMapper
    {        
        public static Cat ToCat(RequestModel catReq)
        {
            return new Cat
            {
                AddedOn = catReq.AddedOn,
                Fact = catReq.Fact,
                Source = catReq.Source
            };
        }
        
        public static ResponseModel ToCatResponse(Cat cat)
        {
            return new ResponseModel
            {
                AddedOn = cat.AddedOn,
                Fact = cat.Fact,
                Source = cat.Source
            };
        }

        public static List<ResponseModel> ToCatResponse(List<Cat> cats)
        {
            var catRes = new List<ResponseModel>();
            cats.ForEach(c =>
            {
                catRes.Add(new ResponseModel
                {
                    AddedOn = c.AddedOn,
                    Fact = c.Fact,
                    Source = c.Source
                });
            });

            return catRes;
        }
    }
}