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
        DbTools db = new DbTools();
        // GET: api/<RaceController>
        [HttpGet]
        public List<Race> GetAllRaces()
        {
            return db.GetListRace("SELECT * FROM Race;");
        }

        // GET api/<RaceController>/5
        [HttpGet("{idRace}")]
        public List<Race> GetOneRace(int idRace)
        {
            return db.GetListRace($"SELECT * FROM Race WHERE idRace = {idRace};");
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
