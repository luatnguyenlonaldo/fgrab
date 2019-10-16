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
    public class TripRepository
    {
        public IConfiguration Configuration { get; }
        public TripRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public bool EvaluateTrip(int tripId, int tripRating)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                int result = connection.Execute("EvaluateTrip"
                    , new
                    {
                        TripId = tripId,
                        TripRating = tripRating
                    }
                    , commandType: CommandType.StoredProcedure);
                return (result > 0);
            }
        }

        public bool BookingTrip(TripModel trip)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                int result = connection.Execute("BookTrip"
                    , new
                    {
                        CustomerID = trip.customerId,
                        DriverId = trip.driverId,
                        RouteId = trip.routeId,
                        SlotId = trip.slotId,
                        BookingDay = trip.BookingDay,
                        TripNote = trip.TripNote
                    }
                    , commandType: CommandType.StoredProcedure);
                return (result > 0);
            }
        }

        public bool CancelTrip(int tripId)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                int result = connection.Execute("CancelTrip"
                    , new
                    {
                        TripId = tripId
                    }
                    , commandType: CommandType.StoredProcedure);
                return (result > 0);
            }
        }

        public bool CompleteTrip(int tripId)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                int result = connection.Execute("CompleteTrip"
                    , new
                    {
                        TripId = tripId
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
