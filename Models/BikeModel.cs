using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FGrabV3.DataAccess
{
    public class BikeModel
    {
        public int BikeId { get; set; }
        public string UserId { get; set; }
        public string BikeName { get; set; }
        public string BikeLicense { get; set; }
        public int BikeTypeId { get; set; }
        public string BikeImage { get; set; }
    }
}
