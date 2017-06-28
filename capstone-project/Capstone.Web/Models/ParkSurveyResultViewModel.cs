using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class ParkSurveyResultViewModel
    {
        public Dictionary<string, SurveyResultModel> ParkSurveyResults { get; set; }
        public Dictionary<string, ParkModel> AllParks { get; set; }
    }
}