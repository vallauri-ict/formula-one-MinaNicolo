using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormulaOneWebServices.DTO
{
    public class DriverDTO
    {
        public int driverNumber { get; set; }
        public string driverName { get; set; }
        public string driverSurname { get; set; }
        public string countryCode { get; set; }
        public string img { get; set; }
        public string teamName { get; set; }

        public DriverDTO(int driverNumber, string driverName, string driverSurname,
            string countryCode, string img, string t)
        {
            this.driverNumber = driverNumber;
            this.driverName = driverName;
            this.driverSurname = driverSurname;
            this.countryCode = countryCode;
            this.img = img;
            this.teamName = t;
        }
    }
}
