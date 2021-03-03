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
    public class ResultController : ControllerBase
    {
        DbTools db = new DbTools();
        // GET: api/<ResultController>
        [HttpGet]
        public List<Result> GetAllResults()
        {
            return db.GetListResult("SELECT * FROM Result;");
        }

        // GET api/<ResultController>/5
        [HttpGet("{id}")]
        public List<Result> GetOneResult(int id)
        {
            return db.GetListResult($"SELECT * FROM Result WHERE id = {id};");
        }

        // POST api/<ResultController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ResultController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ResultController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
