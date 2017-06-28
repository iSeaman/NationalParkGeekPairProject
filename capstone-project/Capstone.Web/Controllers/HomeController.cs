using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParkDAL parkDAL;

        public HomeController(IParkDAL parkDAL)
        {
            this.parkDAL = parkDAL;
        }

        // GET: /
        // GET: Home/
        // GET: Home/Index
        public ActionResult Index()
        {
            List<ParkModel> allParks = parkDAL.GetAllParks();
            return View("Index", allParks);
        }
    }
}