using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tournament.Models
{
    public class EventDetailStatus
    {
        [Column(TypeName = "smallint")]
        public int EventDetailStatusID { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string EventDetailStatusName { get; set; }
    }
}
