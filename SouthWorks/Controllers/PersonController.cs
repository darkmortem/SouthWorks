using SouthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Helpers;

namespace SouthWorks.Controllers
{
  public class PersonController : Controller
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
     public ActionResult ShowPerson()
     {
            List<Person> persons = new List<Person>{
                new Person(){FirstName = "Sherlock" , LastName = "Holmes", Age = "24"},
                new Person(){FirstName = "James" , LastName = "Watson", Age = "32"},
            };
            return View(persons);
        }

    }
}
