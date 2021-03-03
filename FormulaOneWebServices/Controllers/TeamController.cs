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
    public class TeamController : ControllerBase
    {
        DbTools db = new DbTools();
        // GET: api/<TeamsController>
        [Route("api/teams")]
        [HttpGet]
        public List<Team> GetAllTeams()
        {
            return db.GetListTeams("SELECT * FROM Team;");
        }

        [Route("dto/teams/")]
        [HttpGet]
        public List<DTO.TeamDTO> GetTeamDTO()
        {
            List<DTO.TeamDTO> teamList = new List<DTO.TeamDTO>();
            foreach (var team in db.GetListTeams("SELECT * FROM Team;"))
            {
                var driverResult = db.GetListDriver($"SELECT * FROM Driver WHERE teamCode='{team.teamCode}';");
                teamList.Add(new DTO.TeamDTO(driverResult[0], driverResult[1],
                    team.teamFullName, team.logo, team.img));
            }
            return teamList;
        }

        [Route("dto/teams/details")]
        [HttpGet]
        public List<DTO.TeamDetailsDTO> GetTeamDetailsDTO()
        {
            List<DTO.TeamDetailsDTO> teamList = new List<DTO.TeamDetailsDTO>();
            foreach (var team in db.GetListTeams("SELECT * FROM Team;"))
            {
                var driverResult = db.GetListDriver($"SELECT * FROM Driver WHERE teamCode='{team.teamCode}';");
                teamList.Add(new DTO.TeamDetailsDTO(driverResult[0], driverResult[1],
                    team.teamFullName, team.teamChief, team.teamPowerUnit,
                    team.teamBase, team.logo));
            }
            return teamList;
        }

        // GET api/<TeamsController>/5
        [Route("api/teams/{teamCode}")]
        [HttpGet("{teamCode}")]
        public List<Team> GetOneTeam(string teamCode)
        {
            return db.GetListTeams($"SELECT * FROM Team WHERE teamCode='{teamCode}';");
        }

        // GET api/<TeamsController>/teamChief/Franz Tost
        [Route("api/teams/{field}/{value}")]
        [HttpGet("{field}/{value}")]
        public List<Team> Get(string field, string value)
        {
            DbTools db = new DbTools();
            return db.GetTeamDetails(field, value);
        }

        // POST api/<TeamsController>
        /*[HttpPost]
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
        }*/
    }
}
