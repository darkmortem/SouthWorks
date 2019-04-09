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

namespace SouthWorks.Controllers
{
  public class EventController : Controller
  {
        //
        // GET: /Person/

     public ActionResult Home()
      {
            return View();
        }
     public ActionResult Message()
     {
            return View();
        }
     public ActionResult ShowEvent()
     {

            
            /*List<Event> events = new List<Event>{
                new Event(){eventsEventTitle = "JavaConference" , Tecnology = "Java", StartingDate = "24-02-2019", RegistrationLink = "link"},
                new Event(){EventTitle = "CSharpConference" , Tecnology = "CSharp", StartingDate = "24-02-2019", RegistrationLink = "links"},
            };*/
            return View(LoadJson());
     }

    public List<Event> LoadJson()
    {
        List<Event> events;
        using (StreamReader r = new StreamReader("../../EventList.json"))
        {
            string json = r.ReadToEnd();
            events = JsonConvert.DeserializeObject<List<Event>>(json);
        }
        return events;
    }

    }
}
