using System.Collections.Generic;
using AnimalFacts.Presentation.Models;
using AnimalFacts.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Web.AnimalsAPI.Controllers
{
    [Route("rabbitFacts")]
    [ApiController]
    public class RabbitsController : ControllerBase
    {
        private readonly IRabbitService _rabbitService;
        public RabbitsController(IRabbitService rabbitService)
        {
            this._rabbitService = rabbitService;
        }


        // GET: rabbitFacts
        [HttpGet]
        public ActionResult<List<ResponseModel>> Get()
        {
            return Ok(_rabbitService.GetAll());
        }

        // GET rabbitFacts/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (!_rabbitService.RabbitFactExists(id))
                return StatusCode(StatusCodes.Status400BadRequest, "The rabbit could not be found");

            return Ok(_rabbitService.GetById(id));
        }

        // POST rabbitFacts/create
        [HttpPost("create")]
        public ActionResult Post([FromBody] RequestModel rabbit)
        {
            _rabbitService.AddRabbit(rabbit);
            return StatusCode(StatusCodes.Status201Created, $"The rabbit fact has been created.");
        }

        // PUT rabbitFacts/update/5
        [HttpPut("update/{id}")]
        public ActionResult Put([FromBody] RequestModel rabbit, int id)
        {
            if (!_rabbitService.RabbitFactExists(id))
                return StatusCode(StatusCodes.Status400BadRequest, "The rabbit could not be found");

            _rabbitService.UpdateRabbit(rabbit, id);
            return StatusCode(StatusCodes.Status200OK, $"The rabbit fact has been updated.");
        }

        // DELETE rabbitFacts/delete/5
        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            if (!_rabbitService.RabbitFactExists(id))
                return StatusCode(StatusCodes.Status400BadRequest, "The rabbit could not be found");

            _rabbitService.DeleteRabbit(id);
            return StatusCode(StatusCodes.Status200OK, $"The rabbit has been deleted.");
        }
    }
}