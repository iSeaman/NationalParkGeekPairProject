using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDAL : IWeatherDAL
    {
        readonly string connectionString;
        const string SQL_GetParkWeather = "SELECT * FROM weather WHERE parkCode = @parkCode;";

        public WeatherSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<DailyWeatherModel> GetParkWeather(string parkCode)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetParkWeather, conn);
                    cmd.Parameters.AddWithValue("parkCode", parkCode);

                    List<DailyWeatherModel> fiveDayForecast = new List<DailyWeatherModel>();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        fiveDayForecast.Add(PopulateDailyWeatherObject(reader));
                    }

                    return fiveDayForecast;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public DailyWeatherModel PopulateDailyWeatherObject(SqlDataReader reader)
        {
            DailyWeatherModel dwm = new DailyWeatherModel();

            dwm.ParkCode = Convert.ToString(reader["parkCode"]);
            dwm.DayValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
            dwm.LowTemp = Convert.ToInt32(reader["low"]);
            dwm.HighTemp = Convert.ToInt32(reader["high"]);
            dwm.Forecast = Convert.ToString(reader["forecast"]);

            return dwm;
        }
    }
}