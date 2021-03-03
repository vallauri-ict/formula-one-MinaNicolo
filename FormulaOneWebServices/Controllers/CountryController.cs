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
    public class CountryController : ControllerBase
    {
        DbTools db = new DbTools();
        // GET: api/<CountryController>
        [HttpGet]
        public List<Country> GetAllCountries()
        {
            return db.GetListCountry("SELECT * FROM Countries;");
        }

        // GET api/<CountryController>/5
        [HttpGet("{isoCode}")]
        public List<Country> GetOneCountry(string isoCode)
        {
            return db.GetListCountry($"SELECT * FROM Countries WHERE countryCode = '{isoCode.ToUpper()}';");
        }

        // POST api/<CountryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
