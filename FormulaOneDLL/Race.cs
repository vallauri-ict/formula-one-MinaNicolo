using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL
{
    public class Race
    {
        public int idRace { get; set; }
        public string nameRace { get; set; }
        public string circuitId { get; set; }

        public Race(int idRace, string nameRace, string circuitId)
        {
            this.idRace = idRace;
            this.nameRace = nameRace;
            this.circuitId = circuitId;
        }
    }
}
