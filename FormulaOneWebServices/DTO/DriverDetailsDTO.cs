using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOneDLL;

namespace FormulaOneWebServices.DTO
{
    public class DriverDetailsDTO
    {
        public int driverNumber { get; set; }
        public string driverName { get; set; }
        public string driverSurname { get; set; }
        public string img { get; set; }
        public string teamName { get; set; }
        public string countryName { get; set; }
        public int podiums { get; set; }

        public DriverDetailsDTO(int driverNumber, string driverName, string driverSurname, string img, string teamName,
            string countryName, int podiums)
        {
            this.driverNumber = driverNumber;
            this.driverName = driverName;
            this.driverSurname = driverSurname;
            this.img = img;
            this.teamName = teamName;
            this.countryName = countryName;
            this.podiums = podiums;
        }
    }
}
