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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepo _repo;

        public OrdersController(IOrderRepo repo)
        {
            _repo = repo;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok( _repo.GetAll() );
        }

        // GET api/<OrdersController>/5
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
                return NotFound(e.Message);
            }
        }

        // POST api/<OrdersController>
        [HttpPost]
        public ActionResult Post(OrderCreateDto value)
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

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, OrderCreateDto value)
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

        // DELETE api/<OrdersController>/5
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
