using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL
{
    public class Driver
    {
        public int driverNumber { get; set; }
        public string driverName { get; set; }
        public string driverSurname { get; set; }
        public string teamCode { get; set; }
        public string countryCode { get; set; }
        public string img { get; set; }

        public Driver(int dn, string dName, string dSurname,
            string tc, string cc, string img)
        {
            this.driverNumber = dn;
            this.driverName = dName;
            this.driverSurname = dSurname;
            this.teamCode = tc;
            this.countryCode = cc;
            this.img = img;
        }
    }
}
