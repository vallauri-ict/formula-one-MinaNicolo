using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOneDLL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FormulaOneWebServices
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        // GET: api/<TeamsController>
        [HttpGet]
        public List<Team> Get()
        {
            DbTools db = new DbTools();
            return db.GetListTeams(false, null);
        }

        // GET api/<TeamsController>/5
        [HttpGet("{teamCode}")]
        public List<Team> Get(string teamCode)
        {
            DbTools db = new DbTools();
            return db.GetListTeams(true, teamCode);
        }

        // POST api/<TeamsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TeamsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TeamsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
