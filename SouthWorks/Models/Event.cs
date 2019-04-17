using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouthWorks.Models
{
    public class Event
    {
        public String EventTitle { get; set; }
        public String Technology { get; set; }
        public String StartingDate { get; set; }
        public String RegistrationLink { get; set; }
    }

    public class AllEvent
    {
        public List<Event> Items { get; set; }
        public bool HasMoreResults { get; set; }
    }
}