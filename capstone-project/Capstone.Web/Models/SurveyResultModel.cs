using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class SurveyResultModel
    {
        public string ParkCode { get; set; }
        public int NumSurveys { get; set; }
        public int NumInactive { get; set; }
        public int NumSedentary { get; set; }
        public int NumActive { get; set; }
        public int NumExtremelyActive { get; set; }
    }
}