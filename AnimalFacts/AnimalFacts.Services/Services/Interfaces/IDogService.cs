using AnimalFacts.Presentation.Models;
using System.Collections.Generic;


namespace AnimalFacts.Services.Services.Interfaces
{
    public interface IDogService
    {
        List<ResponseModel> GetAll();
        ResponseModel GetById(int id);
        void AddDog(RequestModel dogReq);
        void UpdateDog(RequestModel dogReq, int id);
        void DeleteDog(int id);
        bool DogFactExists(int id);
    }
}