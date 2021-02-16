using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOneDLL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FormulaOneWebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CircuitController : ControllerBase
    {
        // GET: api/<CircuitController>
        [HttpGet]
        public List<Circuit> Get()
        {
            DbTools db = new DbTools();
            return db.GetListCircuit(false, null);
        }

        // GET api/<CircuitController>/5
        [HttpGet("{circuitId}")]
        public List<Circuit> Get(string circuitId)
        {
            DbTools db = new DbTools();
            return db.GetListCircuit(true, circuitId);
        }

        // POST api/<CircuitController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CircuitController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CircuitController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
