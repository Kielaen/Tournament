using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tournament.Models
{
    public class Event
    {
        [Column(TypeName = "bigint")]
        public int EventID { get; set; }
        [ForeignKey("Tournament")]
        public int FK_TournamentID { get; set; }
        //[Column(TypeName = "bigint")]
        public virtual Tournament Tournament { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string EventName { get; set; }
        [Column(TypeName = "smallint")]
        public int EventNumber { get; set; }
        public DateTime EventDateTime { get; set; }
        public DateTime EventEndDateTime { get; set; }
        public bool AutoClose { get; set; }
    }
}
