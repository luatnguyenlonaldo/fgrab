using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FGrabV3.DataAccess;
using FGrabV3.Models;
using Microsoft.AspNetCore.Mvc;

namespace FGrabV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : Controller
    {
        private readonly TripRepository _triprepo;

        public TripController (TripRepository triprepo)
        {
            _triprepo = triprepo;
        }

        [Route("evaluating/{tripId}/{tripRating}")]
        [HttpPut]
        public JsonResult EvaluateTrip(int tripId, int tripRating)
        {
            return Json(_triprepo.EvaluateTrip(tripId, tripRating));
        }

        [Route("booking")]
        [HttpPost]
        public JsonResult BookingTrip(TripModel trip)
        {
            return Json(_triprepo.BookingTrip(trip));
        }

        [Route("canceling/{tripId}")]
        [HttpPut]
        public JsonResult CancelTrip(int tripId)
        {
            return Json(_triprepo.CancelTrip(tripId));
        }

        [Route("completing/{tripId}")]
        [HttpPut]
        public JsonResult CreateNewAccount(int tripId)
        {
            return Json(_triprepo.CompleteTrip(tripId));
        }
    }
}