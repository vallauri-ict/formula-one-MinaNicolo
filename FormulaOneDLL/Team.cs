using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL
{
    public class Team
    {
        public string teamCode { get; set; }
        public string teamFullName { get; set; }
        public string teamChief { get; set; }
        public string teamPowerUnit { get; set; }
        public string teamBase { get; set; }
        public string countryCode { get; set; }
        public string logo { get; set; }
        public string img { get; set; }

        public Team(string teamCode, string teamFullName, string teamChief, string teamPowerUnit, string teamBase,
            string countryCode, string logo, string img)
        {
            this.teamCode = teamCode;
            this.teamFullName = teamFullName;
            this.teamChief = teamChief;
            this.teamPowerUnit = teamPowerUnit;
            this.teamBase = teamBase;
            this.countryCode = countryCode;
            this.logo = logo;
            this.img = img;
        }
    }
}
