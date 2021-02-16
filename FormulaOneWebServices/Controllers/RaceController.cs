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
    public class RaceController : ControllerBase
    {
        // GET: api/<RaceController>
        [HttpGet]
        public List<Race> Get()
        {
            DbTools db = new DbTools();
            return db.GetListRace(false, 0);
        }

        // GET api/<RaceController>/5
        [HttpGet("{idRace}")]
        public List<Race> Get(int idRace)
        {
            DbTools db = new DbTools();
            return db.GetListRace(true, idRace);
        }

        // POST api/<RaceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RaceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RaceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
