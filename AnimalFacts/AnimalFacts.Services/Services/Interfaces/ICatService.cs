using AnimalFacts.Presentation.Models;
using System.Collections.Generic;


namespace AnimalFacts.Services.Services.Interfaces
{
    public interface ICatService
    {
        List<ResponseModel> GetAll();
        ResponseModel GetById(int id);
        void AddCat(RequestModel catReq);
        void UpdateCat(RequestModel catReq, int id);
        void DeleteCat(int id);
        bool CatFactExists(int id);
    }
}