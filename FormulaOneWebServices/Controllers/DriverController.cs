using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOneDLL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FormulaOneWebServices
{
    //[Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        DbTools db = new DbTools();
        // GET: api/<DriverController>
        [Route("")]
        [Route("api/drivers")]
        [HttpGet]
        public List<Driver> GetAllDrivers()
        {   
            return db.GetListDriver("SELECT * FROM Driver");
        }

        // GET api/<DriverController>/5
        [Route("api/drivers/{driverNumber}")]
        [HttpGet("{driverNumber}")]
        public List<Driver> GetOneDriver(int driverNumber)
        {
            return db.GetListDriver($"SELECT * FROM Driver WHERE driverNumber = {driverNumber};");
        }

        [Route("dto/drivers/")]
        [HttpGet]
        public List<DTO.DriverDTO> GetDriverDTO()
        {
            List<DTO.DriverDTO> driverList = new List<DTO.DriverDTO>();
            foreach (var driver in db.GetListDriver("SELECT * FROM Driver"))
            {
                driverList.Add(new DTO.DriverDTO(driver.driverNumber, driver.driverName,
                    driver.driverSurname, driver.countryCode, driver.img,
                    db.GetListTeams($"SELECT * FROM Team WHERE teamCode='{driver.teamCode}';")[0].teamFullName));
            }
            return driverList;
        }

        [Route("dto/drivers/details")]
        [HttpGet]
        public List<DTO.DriverDetailsDTO> GetDriverDetailsDTO()
        {
            List<DTO.DriverDetailsDTO> driverList = new List<DTO.DriverDetailsDTO>();
            foreach (var driver in db.GetListDriver("SELECT * FROM Driver"))
            {
                var country = db.GetListCountry($"SELECT * FROM Countries WHERE countryCode='{driver.countryCode}';");
                driverList.Add(new DTO.DriverDetailsDTO(
                    driver.driverNumber, 
                    driver.driverName,
                    driver.driverSurname, 
                    driver.img,
                    db.GetListTeams($"SELECT * FROM Team WHERE teamCode='{driver.teamCode}';")[0].teamFullName,
                    country[0].countryName,
                    country[0].countryCode,
                    driver.points));
            }
            return driverList;
        }
        // GET api/<DriverController>/driverSurname/Hamilton
        [Route("api/drivers/{field}/{value}")]
        [HttpGet("{field}/{value}")]
        public List<Driver> Get(string field, string value)
        {
            DbTools db = new DbTools();
            return db.GetDriverDetails(field, value);
        }

        // POST api/<DriverController>
        /*[HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DriverController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DriverController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
