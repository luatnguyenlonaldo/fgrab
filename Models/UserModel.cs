using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FGrabV3.DataAccess
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int MajorId { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public string AvatarLink { get; set; }
    }
}
