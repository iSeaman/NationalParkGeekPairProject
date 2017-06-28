using Capstone.Web.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.Tests
{
    public class ParkDoubleDAL : IParkDAL
    {
        public List<ParkModel> GetAllParks()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllParkStates()
        {
            throw new NotImplementedException();
        }

        public ParkModel GetPark(string parkCode)
        {
            throw new NotImplementedException();
        }
    }
}
