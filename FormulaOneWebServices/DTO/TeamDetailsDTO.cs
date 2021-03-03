using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOneDLL;

namespace FormulaOneWebServices.DTO
{
    public class TeamDetailsDTO
    {
        public Driver firstDriver { get; set; }
        public Driver secondDriver { get; set; }
        public string fullNameTeam { get; set; }
        public string chief { get; set; }
        public string powerUnit { get; set; }
        public string teambase { get; set; }
        public string logoTeam { get; set; }

        public TeamDetailsDTO(Driver firstDriver, Driver secondDriver, string fullNameTeam,
            string chief, string powerUnit, string teambase, string logoTeam)
        {
            this.firstDriver = firstDriver;
            this.secondDriver = secondDriver;
            this.fullNameTeam = fullNameTeam;
            this.chief = chief;
            this.powerUnit = powerUnit;
            this.teambase = teambase;
            this.logoTeam = logoTeam;
        }
    }
}
