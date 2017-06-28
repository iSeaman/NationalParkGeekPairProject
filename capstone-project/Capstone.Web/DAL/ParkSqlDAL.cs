using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class ParkSqlDAL: IParkDAL
    {
        readonly string connectionString;
        const string SQL_GetAllParks = "SELECT * FROM park;";
        const string SQL_GetPark = "SELECT * FROM park WHERE parkCode = @parkCode;";
        const string SQL_GetAllParkStates = "SELECT state FROM park GROUP BY state;";


        public ParkSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<ParkModel> GetAllParks()
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetAllParks, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<ParkModel> parks = new List<ParkModel>();

                    while (reader.Read())
                    {
                        parks.Add(PopulateParkModel(reader));
                    }

                    return parks;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public List<string> GetAllParkStates()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetAllParkStates, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<string> states = new List<string>();
                    while (reader.Read())
                    {
                        states.Add(Convert.ToString(reader["state"]));
                    }

                    return states;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public ParkModel GetPark(string parkCode)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetPark, conn);
                    cmd.Parameters.AddWithValue("parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();

                    ParkModel p = new ParkModel();
                    while (reader.Read())
                    {
                        p = PopulateParkModel(reader);
                    }

                    return p;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        private ParkModel PopulateParkModel(SqlDataReader reader)
        {
            ParkModel p = new ParkModel();

            p.ParkCode = Convert.ToString(reader["parkCode"]);
            p.ParkName = Convert.ToString(reader["parkName"]);
            p.State = Convert.ToString(reader["state"]);
            p.Acreage = Convert.ToInt32(reader["acreage"]);
            p.ElevationInFt = Convert.ToInt32(reader["elevationInFeet"]);
            p.MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]);
            p.NumCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
            p.Climate = Convert.ToString(reader["climate"]);
            p.YearFounded = Convert.ToInt32(reader["yearFounded"]);
            p.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
            p.Quote = Convert.ToString(reader["inspirationalQuote"]);
            p.QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
            p.ParkDescription = Convert.ToString(reader["parkDescription"]);
            p.EntryFee = Convert.ToDecimal(reader["entryFee"]);
            p.NumAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

            return p;
        }
    }
}