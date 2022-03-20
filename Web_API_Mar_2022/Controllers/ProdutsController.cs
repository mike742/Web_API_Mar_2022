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
        public IEnumerable<ProductReadDto> Get()
        {
            return _repo.GetAll();
        }

        // GET api/<ProdutsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProdutsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProdutsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProdutsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
