using FGrabV3.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FGrabV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserRepository _userrepo;

        public UserController(UserRepository userrepo)
        {
            _userrepo = userrepo;
        }

        [Route("login/{username}/{password}")]
        [HttpGet]
        public JsonResult LoginAccount(string username, string password)
        {
            return Json(_userrepo.LoginAccount(username, password));
        }

        [Route("userbyid/{username}")]
        [HttpGet]
        public JsonResult GetUserById(string username)
        {
            return Json(_userrepo.GetUserById(username));
        }

        [Route("searchingAvailableDriver/{startPoint}/{endPoint}/{dateBooking}/{slot}")]
        [HttpGet]
        public JsonResult SearchAvailableDriver(int startPoint, int endPoint, DateTime dateBooking, int slot)
        {
            return Json(_userrepo.SearchAvailableDriver(startPoint, endPoint, dateBooking, slot));
        }

        [HttpPost]
        public JsonResult CreateNewAccount(UserModel user)
        {
            return Json(_userrepo.CreateNewAccount(user));
        }

        [HttpPut]
        public JsonResult UpdateUserInfo(UserModel user)
        {
            return Json(_userrepo.UpdateUserInfo(user));
        }

        [Route("loginandget/{username}/{password}")]
        [HttpGet]
        public JsonResult LoginAndGetInfo(string username, string password)
        {
            return Json(_userrepo.LoginAndGetInfo(username, password));
        }
    }
}