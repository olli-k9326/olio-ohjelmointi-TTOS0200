using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
    public class Kiuas
    {
        public bool OnkoPäällä { get; set; }
        public float Lämpötila { get; set; }
        // kosteus voi olla välillä 0-100
        float kosteus;
        public float Kosteus {
            get {return kosteus;}
            
            set
            {
                kosteus = value;
                if (kosteus < 0 || kosteus > 100)
                    kosteus = 0;
            }
        }


    }
}
