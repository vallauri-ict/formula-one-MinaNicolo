using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL
{
    public class Circuit
    {
        public string circuitId { get; set; }
        public string circuitName { get; set; }
        public string circuitNation { get; set; }
        public int turnNumber { get; set; }
        public int circuitLength { get; set; }
        public string fastestLap { get; set; }
        public string thumbnailImg { get; set; }
        public string descriptionImg { get; set; }

        public Circuit(string circuitId, string circuitName, string circuitNation, 
            int turnNumber, int circuitLength, string fastestLap, 
            string thumbnailImg, string descriptionImg)
        {
            this.circuitId = circuitId;
            this.circuitName = circuitName;
            this.circuitNation = circuitNation;
            this.turnNumber = turnNumber;
            this.circuitLength = circuitLength;
            this.fastestLap = fastestLap;
            this.thumbnailImg = thumbnailImg;
            this.descriptionImg = descriptionImg;
        }
    }
}
