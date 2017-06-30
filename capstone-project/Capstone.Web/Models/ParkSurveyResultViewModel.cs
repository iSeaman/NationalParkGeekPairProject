using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class ParkSurveyResultViewModel
    {
        public List<SurveyResultModel> ParksSurveyResults { get; set; }
        public Dictionary<string, ParkModel> ParksDict { get; set; }
    }
}