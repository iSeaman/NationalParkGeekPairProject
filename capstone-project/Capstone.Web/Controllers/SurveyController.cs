using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyDAL surveyDAL;
        private IParkDAL parkDAL;

        public SurveyController(ISurveyDAL surveyDAL, IParkDAL parkDAL)
        {
            this.surveyDAL = surveyDAL;
            this.parkDAL = parkDAL;
        }

        public ActionResult Index()
        {
            return RedirectToAction("TakeSurvey");
        }

        [HttpGet]
        public ActionResult TakeSurvey()
        {
            List<ParkModel> parks = parkDAL.GetAllParks();
            SurveyFormModel emptySurvey = new SurveyFormModel();
            emptySurvey.AvailableParks = parks;

            return View("TakeSurvey", emptySurvey);
        }

        [HttpPost]
        public ActionResult TakeSurvey(SurveyFormModel survey)
        {
            if (!ModelState.IsValid)
            {
                return View("TakeSurvey");
            }
            surveyDAL.SaveSurveyForm(survey);
            return RedirectToAction("Results");
        }

        public ActionResult Results()
        {
            return View("Results");
        }

    }
}