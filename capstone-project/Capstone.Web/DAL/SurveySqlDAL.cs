using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAL : ISurveyDAL
    {
        readonly string connectionString;
        const string SQL_GetSurveyResultsCount = "SELECT COUNT(*) FROM survey_result WHERE parkCode = @parkCode;";
        const string SQL_SaveSurveyForm = "INSERT INTO survey_result VALUES (@parkCode, @emailAddress, @state, @activityLevel);";
        const string SQL_GetParkActivityCount = "SELECT COUNT(*) FROM survey_result WHERE parkCode = @parkCode AND activityLevel = ";

        public SurveySqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SurveyResultModel GetParkSurveyResults(string parkCode)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Get total number of surveys completed for park
                    SqlCommand cmd = new SqlCommand(SQL_GetSurveyResultsCount, conn);
                    cmd.Parameters.AddWithValue("parkCode", parkCode);
                    int surveyCount = Convert.ToInt32(cmd.ExecuteScalar());

                    // Get count of activity levels listed on this park's surveys
                    Dictionary<string, int> activityTypeCount = new Dictionary<string, int>();
                    List<string> activityType = new List<string>()
                    {
                        "inactive", "sedentary", "active", "extremely active"
                    };

                    foreach (string s in activityType)
                    {
                        string finalQuery = SQL_GetParkActivityCount + "'" + s + "';";
                        cmd = new SqlCommand(finalQuery, conn);
                        activityTypeCount[s] = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Populate and return SurveyResultModel
                    SurveyResultModel completedSurvey = new SurveyResultModel();
                    completedSurvey.ParkCode = parkCode;
                    completedSurvey.NumSurveys = surveyCount;
                    completedSurvey.NumInactive = activityTypeCount["inactive"];
                    completedSurvey.NumSedentary = activityTypeCount["sedentary"];
                    completedSurvey.NumActive = activityTypeCount["active"];
                    completedSurvey.NumExtremelyActive = activityTypeCount["extremely active"];

                    return completedSurvey;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public bool SaveSurveyForm(SurveyFormModel surveyForm)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_SaveSurveyForm, conn);
                    cmd.Parameters.AddWithValue("parkCode", surveyForm.ParkCode);
                    cmd.Parameters.AddWithValue("emailAddress", surveyForm.Email);
                    cmd.Parameters.AddWithValue("state", surveyForm.State);
                    cmd.Parameters.AddWithValue("activityLevel", surveyForm.ActivityLevel);

                    int numRowsAffected = cmd.ExecuteNonQuery();

                    return numRowsAffected > 0;
                }
            }
            catch (SqlException)
            {

                throw;
            }
        }
    }
}