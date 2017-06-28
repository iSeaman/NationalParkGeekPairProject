using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class ParkModel
    {
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public string State { get; set; }
        public int Acreage { get; set; }
        public int ElevationInFt { get; set; }
        public double MilesOfTrail { get; set; }
        public int NumCampsites { get; set; }
        public string Climate { get; set; }
        public int YearFounded { get; set; }
        public int AnnualVisitorCount { get; set; }
        public string Quote { get; set; }
        public string QuoteSource { get; set; }
        public string ParkDescription { get; set; }
        public decimal EntryFee { get; set; }
        public int NumAnimalSpecies { get; set; }
    }
}