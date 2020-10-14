using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tournament.ViewModels
{
    public class EventViewModel
    {
       
        public int EventID { get; set; }      
        public int FK_TournamentID { get; set; }
        public string TournamentName { get; set; }        
        public string EventName { get; set; }
        public int EventNumber { get; set; }
        public DateTime EventDateTime { get; set; }
        public DateTime EventEndDateTime { get; set; }
        public string EventDateTimeString { get; set; }
        public string EventEndDateTimeString { get; set; }
        public bool AutoClose { get; set; }
    }
}
