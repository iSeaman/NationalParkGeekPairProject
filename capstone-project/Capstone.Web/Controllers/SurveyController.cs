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
                List<ParkModel> parks = parkDAL.GetAllParks();
                survey.AvailableParks = parks;
                return View("TakeSurvey", survey);
            }
            surveyDAL.SaveSurveyForm(survey);
            return RedirectToAction("Results");
        }

        public ActionResult Results()
        {
            List<ParkModel> parks = parkDAL.GetAllParks();
            Dictionary<string, ParkModel> parksDict = new Dictionary<string, ParkModel>();
            List<SurveyResultModel> parksSurveyResults = new List<SurveyResultModel>();

            foreach (ParkModel park in parks)
            {
                // Add key-value pair to parksDict
                parksDict[park.ParkCode] = park;

                // Add to parksSurveyResults
                SurveyResultModel results = surveyDAL.GetParkSurveyResults(park.ParkCode);
                if (results.NumSurveys >= 1)
                {
                    parksSurveyResults.Add(results);
                }
            }

            ParkSurveyResultViewModel surveySummaries = new ParkSurveyResultViewModel();
            surveySummaries.ParksDict = parksDict;
            surveySummaries.ParksSurveyResults = parksSurveyResults.OrderBy(p => p.NumSurveys).Reverse().ToList();
            return View("Results", surveySummaries);
        }

    }
}