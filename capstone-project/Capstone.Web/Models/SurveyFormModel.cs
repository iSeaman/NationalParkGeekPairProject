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
        // VARIABLE
        private List<string> states = new List<string>()
        {
            "Alabama",
            "Alaska",
            "Arizona",
            "Arkansas",
            "California",
            "Colorado",
            "Connecticut",
            "Delaware",
            "Florida",
            "Georgia",
            "Hawaii",
            "Idaho",
            "Illinois",
            "Indiana",
            "Iowa",
            "Kansas",
            "Kentucky",
            "Louisiana",
            "Maine",
            "Maryland",
            "Massachusetts",
            "Michigan",
            "Minnesota",
            "Mississippi",
            "Missouri",
            "Montana",
            "Nebraska",
            "Nevada",
            "New Hampshire",
            "New Jersey",
            "New Mexico",
            "New York",
            "North Carolina",
            "North Dakota",
            "Ohio",
            "Oklahoma",
            "Oregon",
            "Pennsylvania",
            "Rhode Island",
            "South Carolina",
            "South Dakota",
            "Tennessee",
            "Texas",
            "Utah",
            "Vermont",
            "Virginia",
            "Washington",
            "West Virginia",
            "Wisconsin",
            "Wyoming"
        };

        // PROPERTIES
        public int SurveyID { get; set; }

        // Email Address
        [Required(ErrorMessage = "*Required Field")]
        [Display(Name = "Your Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        // State
        [Required(ErrorMessage = "*Required Field")]
        [Display(Name = "State of Residence")]
        public string State { get; set; }
        public List<SelectListItem> StateChoices
        {
            get { return CreateStateChoices(); }
        }

        // Park
        [Required(ErrorMessage = "*Required Field")]
        [Display(Name = "Favorite Park")]
        public string ParkCode { get; set; }
        public List<ParkModel> AvailableParks { get; set; }
        public List<SelectListItem> ParkChoices
        {
            get { return CreateParkChoices(AvailableParks); }
        }

        // Activity Level
        [Required(ErrorMessage = "*Required Field")]
        public string ActivityLevel { get; set; }
        public List<string> ActivityType = new List<string>()
        {
            "Inactive", "Sedentary", "Active", "Extremely Active"
        };

        // METHODS
        private List<SelectListItem> CreateParkChoices (List<ParkModel> parks)
        {
            List<SelectListItem> choices = new List<SelectListItem>();

            foreach (ParkModel p in parks)
            {
                choices.Add(new SelectListItem { Text = p.ParkName, Value = p.ParkCode });
            }

            return choices;
        }

        private List<SelectListItem> CreateStateChoices ()
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