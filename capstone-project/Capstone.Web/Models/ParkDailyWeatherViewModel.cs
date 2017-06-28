using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class ParkDailyWeatherViewModel
    {
        public ParkModel Park { get; set; }
        public List<DailyWeatherModel> FiveDayForecast { get; set; }
    }
}