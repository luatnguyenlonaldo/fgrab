using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FGrabV3.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace FGrabV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : Controller
    {
        private readonly PointRepository _pointrepo;

        public PointController(PointRepository pointrepo)
        {
            _pointrepo = pointrepo;
        }

        [HttpGet]
        public JsonResult GetAllTrip()
        {
            return Json(_pointrepo.GetAllPoint());
        }

        [Route("{pointId}")]
        [HttpGet]
        public JsonResult GetMatchPoint(int pointId)
        {
            return Json(_pointrepo.GetMatchPoint(pointId));
        }
    }
}