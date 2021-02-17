using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL
{
    public class Result
    {
        public int id { get; set; }
        public int raceId { get; set; }
        public int driverId { get; set; }
        public string teamId { get; set; }
        public string driverTime { get; set; }
        public int driverPosition { get; set; }
        public int driverLaps { get; set; }
        public int driverFastestLap { get; set; }

        public Result(int id, int raceId, int driverId, string teamId, string driverTime, 
            int driverPosition, int driverLaps, int driverFastestLap)
        {
            this.id = id;
            this.raceId = raceId;
            this.driverId = driverId;
            this.teamId = teamId;
            this.driverTime = driverTime;
            this.driverPosition = driverPosition;
            this.driverLaps = driverLaps;
            this.driverFastestLap = driverFastestLap;
        }
    }
}
