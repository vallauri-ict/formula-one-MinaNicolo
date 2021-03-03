using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOneDLL;

namespace FormulaOneWebServices.DTO
{
    public class TeamDTO
    {
        public Driver firstDriver { get; set; }
        public Driver secondDriver { get; set; }
        public string fullNameTeam { get; set; }
        public string logoTeam { get; set; }
        public string imgCar { get; set; }

        public TeamDTO(Driver firstDriver, Driver secondDriver, string name, string logo, string imgCar)
        {
            this.firstDriver = firstDriver;
            this.secondDriver = secondDriver;
            this.fullNameTeam = name;
            this.logoTeam = logo;
            this.imgCar = imgCar;
        }
    }
}
