using SouthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Web.Caching;
using System.Web.UI;

namespace SouthWorks.Controllers
{
  [HandleError]
  public class EventController : Controller
  {
        [OutputCache(Duration = 3600, VaryByParam = "none")]
        public ActionResult Home()
        {
            return View();
        }

        [OutputCache(Duration = 3600, VaryByParam = "none", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult ShowEvent()
        {
            return View(LoadJson());
        }

        [OutputCache(Duration = 3600, VaryByParam = "none", Location = OutputCacheLocation.Client, NoStore = true)]
        public List<Event> LoadJson()
        {
        List<Event> events;

            using (StreamReader r = new StreamReader("../../EventList.json"))
            {
                string json = r.ReadToEnd();
                var serializer = new JavaScriptSerializer();
              //  events = JsonConvert.DeserializeObject<List<Event>>(json);
            }

            if (HttpRuntime.Cache["Events"] == null)
            {
                string myConnectionString = ConfigurationManager.ConnectionStrings["SouthWorkDB"].ConnectionString;
                //Create your Sql Connection here
                using (SqlConnection con = new SqlConnection(myConnectionString))
                {
                    //Open the sql connection
                    con.Open();
                    events = getEventsFromDB(con);
                }
                // Create the Sql Cache dependency object to use it on ur cache.
                // First parameter is the database name, second the table to create the dependency. SouthWorkDB
                SqlCacheDependency SQL_DEPENDENCY = new SqlCacheDependency("SouthWorkDBCache", "Events");
                HttpRuntime.Cache.Insert("Events", events, SQL_DEPENDENCY);
            }
            else
            {
                events = HttpRuntime.Cache["Events"] as List<Event>;
            }
            return events;
        }


        static List<Event> getEventsFromDB(SqlConnection con)
        {
            try
            {
                Event eventobj = new Event();
                List<Event> active = new List<Event>();
                string selectQuery = @"SELECT * FROM Events";

                SqlCommand cmd = new SqlCommand(selectQuery, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var eventObject = new Event();
                    eventObject.EventTitle = reader[1].ToString();
                    eventObject.Technology = reader[2].ToString();
                    eventObject.StartingDate = reader[3].ToString();
                    eventObject.RegistrationLink = reader[4].ToString();

                    active.Add(eventObject);
                }
                return active;

            }
            catch (Exception eventObject)
            {
                return null;
            }
        }


    }
}
