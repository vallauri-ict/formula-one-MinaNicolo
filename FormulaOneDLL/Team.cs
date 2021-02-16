using System;
using System.Collections.Generic;
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

        public Team(string tc, string tfn, string tchief, string tpu,
            string tb, string cc, string logo, string img)
        {
            this.teamCode = tc;
            this.teamFullName = tfn;
            this.teamChief = tchief;
            this.teamPowerUnit = tpu;
            this.teamBase = tb;
            this.countryCode = cc;
            this.logo = logo;
            this.img = img;
        }
    }
}
