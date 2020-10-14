using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tournament.Models
{
    public class EventDetail
    {
        [Column(TypeName = "bigint")]
        public int EventDetailID { get; set; }
        [ForeignKey("Event")]
        public int FK_EventID { get; set; }
        //[Column("FK_Event",TypeName = "bigint")]
        public virtual Event Event { get; set; }
        [ForeignKey("EventDetailStatus")]
        public int FK_EventDetailStatusID { get; set; }
       // [Column(TypeName = "smallint")]
        public virtual EventDetailStatus EventDetailStatus { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string EventDetailName { get; set; }
        [Column(TypeName = "smallint")]
        public int EventDetailNumber { get; set; }
        [Column(TypeName = "decimal(18,7)")]
        public decimal EventDetailOdd { get; set; }
        [Column(TypeName = "smallint")]
        public int FinishingPosition { get; set; }
        public bool FirstTimer { get; set; }
    }
}
