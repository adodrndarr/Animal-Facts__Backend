using System.Collections.Generic;
using AnimalFacts.Presentation.Models;
using AnimalFacts.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Web.AnimalsAPI.Controllers
{
    [Route("catFacts")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        private readonly ICatService _catService;
        public CatsController(ICatService catService)
        {
            this._catService = catService;
        }


        // GET: catFacts
        [HttpGet]
        public ActionResult<List<ResponseModel>> Get()
        {
            return Ok(_catService.GetAll());
        }

        // GET catFacts/5 
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (!_catService.CatFactExists(id))
                return StatusCode(StatusCodes.Status400BadRequest, "The cat could not be found");

            return Ok(_catService.GetById(id));
        }

        // POST catFacts/create
        [HttpPost("create")]
        public ActionResult Post([FromBody] RequestModel cat)
        {
            _catService.AddCat(cat);
            return StatusCode(StatusCodes.Status201Created, $"The cat fact has been created.");
        }

        // PUT catFacts/update/5 
        [HttpPut("update/{id}")]
        public ActionResult Put([FromBody] RequestModel cat, int id)
        {
            if (!_catService.CatFactExists(id))
                return StatusCode(StatusCodes.Status400BadRequest, "The cat could not be found");

            _catService.UpdateCat(cat, id);
            return StatusCode(StatusCodes.Status200OK, $"The cat fact has been updated.");
        }

        // DELETE catFacts/delete/5 
        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            if (!_catService.CatFactExists(id))
                return StatusCode(StatusCodes.Status400BadRequest, "The cat could not be found");

            _catService.DeleteCat(id);
            return StatusCode(StatusCodes.Status200OK, $"The cat has been deleted.");
        }
    }
}