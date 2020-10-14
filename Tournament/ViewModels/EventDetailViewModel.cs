using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tournament.ViewModels
{
    public class EventDetailViewModel
    {
      
        public int EventDetailID { get; set; }
      
        public int FK_EventID { get; set; }
      
        public int FK_EventDetailStatusID { get; set; }
      
       public string EventName { get; set; }
        public string EventDetailStatusName { get; set; }
        public string EventDetailName { get; set; }
       
        public int EventDetailNumber { get; set; }
       
        public decimal EventDetailOdd { get; set; }
      
        public int FinishingPosition { get; set; }
        public bool FirstTimer { get; set; }
    }
}
