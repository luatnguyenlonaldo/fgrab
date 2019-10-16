using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FGrabV3.Models
{
    public class TripModel
    {
        public int TripID { get; set; }
        public string customerId { get; set; }
        public string driverId { get; set; }
        public int routeId { get; set; }
        public int slotId { get; set; }
        public DateTime BookingDay { get; set; }
        public string TripNote { get; set; }
        public int TripStatusId { get; set; }
        public int TripRating { get; set; }
    }
}
