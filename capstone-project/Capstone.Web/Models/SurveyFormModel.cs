using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Web.Models
{
    public class SurveyFormModel
    {
        // VARIABLES
        private List<SelectListItem> parkChoices;
        private List<SelectListItem> stateChoices;

        // CONSTRUCTOR
        public SurveyFormModel(List<ParkModel> parks, List<string> states)
        {
            parkChoices = CreateParkChoices(parks);
            stateChoices = CreateStateChoices(states);
        }
        
        // PROPERTIES
        public int SurveyID { get; set; }

        // Email Address
        [Required(ErrorMessage = "*Required Field")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        // State
        [Required(ErrorMessage = "*Required Field")]
        public string State { get; set; }
        public List<SelectListItem> StateChoices
        {
            get { return stateChoices; }
        }

        // Park
        [Required(ErrorMessage = "*Required Field")]
        public string ParkCode { get; set; }
        public List<SelectListItem> ParkChoices
        {
            get { return parkChoices; }
        }

        // Activity Level
        [Required(ErrorMessage = "*Required Field")]
        public string ActivityLevel { get; set; }
        public List<string> ActivityType = new List<string>()
        {
            "Inactive", "Sedentary", "Active", "Extremely Active"
        };

        // METHODS
        public List<SelectListItem> CreateParkChoices (List<ParkModel> parks)
        {
            List<SelectListItem> choices = new List<SelectListItem>();

            foreach (ParkModel p in parks)
            {
                choices.Add(new SelectListItem { Text = p.ParkName, Value = p.ParkCode });
            }

            return choices;
        }

        public List<SelectListItem> CreateStateChoices (List<string> states)
        {
            List<SelectListItem> stateChoices = new List<SelectListItem>();

            foreach (string s in states)
            {
                stateChoices.Add(new SelectListItem { Text = s, Value = s });
            }

            return stateChoices;
        }
    }
}