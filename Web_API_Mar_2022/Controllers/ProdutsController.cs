using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_Mar_2022.Data.Interfaces;
using Web_API_Mar_2022.ModelDto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API_Mar_2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutsController : ControllerBase
    {
        private readonly IProductRepo _repo;

        public ProdutsController(IProductRepo repo)
        {
            _repo = repo;
        }


        // GET: api/<ProdutsController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok( _repo.GetAll() );
        }
            
        // GET api/<ProdutsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var res = _repo.GetById(id);
                return Ok(res);
            }
            catch (Exception e)
            {
                return NotFound(e.Message); // 404
            }    
        }

        // POST api/<ProdutsController>
        [HttpPost]
        public ActionResult Post(ProductCreateDto value)
        {
            try
            {
                _repo.Create(value);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // PUT api/<ProdutsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, ProductCreateDto value)
        {
            try
            {
                _repo.Update(id, value);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // DELETE api/<ProdutsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
