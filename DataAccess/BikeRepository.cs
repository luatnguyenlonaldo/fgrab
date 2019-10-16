using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace FGrabV3.DataAccess
{
    public class BikeRepository
    {
        public IConfiguration Configuration { get; }
        public BikeRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private string GetConnectionString()
        {
            return Configuration["ConnectionStrings:DefaultConnection"];
        }

        public bool CreateBike(BikeModel bike)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                var result = connection.Execute("CreateNewBike"
                    , new { UserId = bike.UserId, BikeName = bike.BikeName, BikeLicense = bike.BikeLicense, BikeTypeId = bike.BikeTypeId, BikeImage = bike.BikeImage }
                    , commandType: CommandType.StoredProcedure);
                return (result > 0);
            }
        }

        public BikeModel GetBikeOfUser(string username)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                var resultData = connection.Query<BikeModel>("GetBikeOfUser"
                    , new { Username = username }
                    , commandType: CommandType.StoredProcedure);
                return resultData.FirstOrDefault<BikeModel>();
            }
        }

        public bool DeleteBikeOfUser(string username, int bikeId)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                var result = connection.Execute("DeleteBike"
                    , new { Username = username, BikeId = bikeId }
                    , commandType: CommandType.StoredProcedure);
                return (result > 0);
            }
        }
    }
}
