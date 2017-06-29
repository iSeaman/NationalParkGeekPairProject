using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class ParkDailyWeatherViewModel
    {
        // Properties
        public ParkModel Park { get; set; }
        public List<DailyWeatherModel> FiveDayForecast { get; set; }
        public List<DailyWeatherModel> CelsiusFiveDayForecast
        {
            get { return FahrenheitToCelsiusForecast(); }
        }

        // Methods
        public List<DailyWeatherModel> FahrenheitToCelsiusForecast ()
        {
            List<DailyWeatherModel> newForecast = new List<DailyWeatherModel>()
            {
                new DailyWeatherModel(),
                new DailyWeatherModel(),
                new DailyWeatherModel(),
                new DailyWeatherModel(),
                new DailyWeatherModel()
            };

            for (int i = 0; i < FiveDayForecast.Count; i++)
            {
                newForecast[i].ParkCode = FiveDayForecast[i].ParkCode;
                newForecast[i].DayValue = FiveDayForecast[i].DayValue;
                newForecast[i].Forecast = FiveDayForecast[i].Forecast;
                newForecast[i].HighTemp = ConvertToCelsius(FiveDayForecast[i].HighTemp);
                newForecast[i].LowTemp = ConvertToCelsius(FiveDayForecast[i].LowTemp);
            }

            return newForecast;
        }

        public int ConvertToCelsius(int tempInFahrenheit)
        {
            return (int) ((tempInFahrenheit - 32.0) * (5.0 / 9));
        }
    }
}