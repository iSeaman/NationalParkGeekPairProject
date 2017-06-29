using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class ParksController : Controller
    {
        private IParkDAL parkDAL;
        private IWeatherDAL weatherDAL;

        public ParksController(IParkDAL parkDAL, IWeatherDAL weatherDAL)
        {
            this.parkDAL = parkDAL;
            this.weatherDAL = weatherDAL;
        }

        public ActionResult Index()
        {
            return RedirectToAction("View");
        }

        public ActionResult View(string parkCode)
        {
            ParkModel park = parkDAL.GetPark(parkCode);
            if (park == null)
            {
                return HttpNotFound();
            }

            List<DailyWeatherModel> fiveDayForecast = weatherDAL.GetParkWeather(parkCode);
            ParkDailyWeatherViewModel parkWeather = new ParkDailyWeatherViewModel()
            {
                Park = park,
                FiveDayForecast = fiveDayForecast
            };

            return View("View", parkWeather);
        }

        public ActionResult ChangeTempSetting(string parkCode)
        {
            if (Session["tempSetting"] as string == "Celsius")
            {
                Session["tempSetting"] = "Fahrenheit";
            }
            else
            {
                Session["tempSetting"] = "Celsius";
            }
            return RedirectToAction("View", new { parkCode = parkCode});
        }
    }
}