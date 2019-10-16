using FGrabV3.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace FGrabV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeController : Controller
    {
        private readonly BikeRepository _bikerepo;

        public BikeController(BikeRepository bikerepo)
        {
            _bikerepo = bikerepo;
        }

        [Route("{username}")]
        [HttpGet]
        public JsonResult GetBikeOfUser(string username)
        {
            return Json(_bikerepo.GetBikeOfUser(username));
        }

        [HttpPost]
        public JsonResult CreateNewBike(BikeModel bike)
        {
            return Json(_bikerepo.CreateBike(bike));
        }

        [Route("deletingBike/{username}/{bikeId}")]
        [HttpPut]
        public JsonResult DeleteBike(string username, int bikeId)
        {
            return Json(_bikerepo.DeleteBikeOfUser(username, bikeId));
        }
    }
}