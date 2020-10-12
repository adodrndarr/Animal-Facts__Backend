using AnimalFacts.Presentation.Models;
using System.Collections.Generic;


namespace AnimalFacts.Services.Services.Interfaces
{
    public interface IRabbitService
    {
        List<ResponseModel> GetAll();
        ResponseModel GetById(int id);
        void AddRabbit(RequestModel rabbitReq);
        void UpdateRabbit(RequestModel rabbitReq, int id);
        void DeleteRabbit(int id);
        bool RabbitFactExists(int id);
    }
}