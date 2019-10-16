using Dapper;
using FGrabV3.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FGrabV3.DataAccess
{
    public class PointRepository
    {
        public IConfiguration Configuration { get; }
        public PointRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<PointModel> GetAllPoint()
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                var result = connection.Query<PointModel>("GetAllPoint"
                    , null
                    , commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public List<PointModel> GetMatchPoint(int pointId)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                var result = connection.Query<PointModel>("GetMatchPoint"
                    , new
                    {
                        PointId = pointId
                    }
                    , commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        private string GetConnectionString()
        {
            return Configuration["ConnectionStrings:DefaultConnection"];
        }
    }
}
