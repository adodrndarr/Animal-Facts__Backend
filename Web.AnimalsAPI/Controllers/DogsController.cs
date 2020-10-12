using System.Collections.Generic;
using AnimalFacts.Presentation.Models;
using AnimalFacts.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Web.AnimalsAPI.Controllers
{
    [Route("dogFacts")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private readonly IDogService _dogService;
        public DogsController(IDogService dogService)
        {
            this._dogService = dogService;
        }


        // GET: dogFacts
        [HttpGet]
        public ActionResult<List<ResponseModel>> Get()
        {
            return Ok(_dogService.GetAll());
        }

        // GET dogFacts/5 
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (!_dogService.DogFactExists(id)) 
                return StatusCode(StatusCodes.Status400BadRequest, "The dog could not be found");

            return Ok(_dogService.GetById(id));
        }

        // POST dogFacts/create
        [HttpPost("create")]
        public ActionResult Post([FromBody] RequestModel dog)
        {
            _dogService.AddDog(dog);
            return StatusCode(StatusCodes.Status201Created, $"The dog fact has been created.");
        }

        // PUT dogFacts/update/5 
        [HttpPut("update/{id}")]
        public ActionResult Put([FromBody] RequestModel dog, int id)
        {
            if (!_dogService.DogFactExists(id))
                return StatusCode(StatusCodes.Status400BadRequest, "The dog could not be found");

            _dogService.UpdateDog(dog, id);
            return StatusCode(StatusCodes.Status200OK, $"The dog fact has been updated.");
        }

        // DELETE dogFacts/delete/5 
        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            if (!_dogService.DogFactExists(id))
                return StatusCode(StatusCodes.Status400BadRequest, "The dog could not be found");

            _dogService.DeleteDog(id);
            return StatusCode(StatusCodes.Status200OK, $"The dog has been deleted.");
        }
    }
}