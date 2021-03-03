using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOneDLL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FormulaOneWebServices.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class CircuitController : ControllerBase
    {
        DbTools db = new DbTools();
        // GET: api/<CircuitController>
        [Route("")]
        [Route("api/circuits")]
        [HttpGet]
        public List<Circuit> GetAllCircuits()
        {
            return db.GetListCircuit("SELECT * FROM Circuit;");
        }

        // GET api/<CircuitController>/5
        [Route("api/circuits/{circuitId}")]
        [HttpGet("{circuitId}")]
        public List<Circuit> GetOneCirtuit(string circuitId)
        {
            return db.GetListCircuit($"SELECT * FROM Circuit WHERE circuitId = '{circuitId}';");
        }

        [Route("dto/circuits/")]
        [HttpGet]
        public List<DTO.CircuitsDTO> GetDetails()
        {
            List<DTO.CircuitsDTO> circuitList = new List<DTO.CircuitsDTO>();
            foreach (var circuit in db.GetListCircuit("SELECT * FROM Circuit"))
            {
                circuitList.Add(new DTO.CircuitsDTO(circuit.circuitName, circuit.circuitNation,
                    circuit.thumbnailImg));
            }
            return circuitList;
        }


        // POST api/<CircuitController>
        /*[HttpPost]
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
        }*/
    }
}
