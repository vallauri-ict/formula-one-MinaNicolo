using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormulaOneWebServices.DTO
{
    public class CircuitsDTO
    {
        public string circuitName { get; set; }
        public string circuitNation { get; set; }
        public string thumbnailImage { get; set; }

        public CircuitsDTO(string circuitName, string circuitNation, string thumbnailImage)
        {
            this.circuitName = circuitName;
            this.circuitNation = circuitNation;
            this.thumbnailImage = thumbnailImage;
        }
    }
}
