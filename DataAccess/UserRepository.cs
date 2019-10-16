using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace FGrabV3.DataAccess
{
    public class UserRepository
    {
        public IConfiguration Configuration { get; }
        public UserRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public bool LoginAccount(string username, string password)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                var listUsers = connection.Query<UserModel>("LoginAccount"
                    , new {Username = username, Password = password}
                    , commandType: CommandType.StoredProcedure);
                return (listUsers.Count() > 0);
            }
        }

        public List<UserModel> SearchAvailableDriver(int startPoint, int endPoint, DateTime dateBooking, int slot)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                var result = connection.Query<UserModel>("SearchAvailableDriver"
                    , new
                    {
                        StartPoint = startPoint,
                        EndPoint = endPoint,
                        BookingDay = dateBooking,
                        SlotId = slot
                    }
                    , commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public UserModel GetUserById(string username)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                var user = connection.Query<UserModel>("GetUserInfor"
                    , new { UserName = username }
                    , commandType: CommandType.StoredProcedure);
                return user.FirstOrDefault<UserModel>();
            }
        }

        public UserModel LoginAndGetInfo(string username, string password)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                var user = connection.Query<UserModel>("LoginAndGetInfoUser"
                    , new { UserName = username, Password = password }
                    , commandType: CommandType.StoredProcedure);
                return user.FirstOrDefault<UserModel>();
            }
        }

        public bool CreateNewAccount(UserModel user)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                int result = connection.Execute("CreateAccount"
                    , new
                    {
                        UserName = user.Username,
                        Password = user.Password,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Gender = user.Gender,
                        Address = user.Address,
                        Email = user.Email,
                        MajorId = user.MajorId,
                        PhoneNumber = user.PhoneNumber
                    }
                    , commandType: CommandType.StoredProcedure);
                return (result > 0);
            }
        }

        public bool UpdateUserInfo(UserModel user)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                int result = connection.Execute("UpdateAccountInfo"
                    , new
                    {
                        UserName = user.Username,
                        Password = user.Password,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Gender = user.Gender,
                        Address = user.Address,
                        Email = user.Email,
                        MajorId = user.MajorId,
                        PhoneNumber = user.PhoneNumber,
                        AvatarLink = user.AvatarLink
                    }
                    , commandType: CommandType.StoredProcedure);
                return (result > 0);
            }
        }

        private bool ChangePassword(string username, string newPassword)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                int result = connection.Execute("ChangePassword"
                    , new
                    {
                        UserName = username,
                        NewPassword = newPassword
                    }
                    , commandType: CommandType.StoredProcedure);
                return (result > 0);
            }
        }

        private string GetConnectionString()
        {
            return Configuration["ConnectionStrings:DefaultConnection"];
        }
    }
}
