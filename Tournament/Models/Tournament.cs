using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tournament.Models
{
    public class Tournament
    {
        [Column(TypeName = "bigint")]
        public int TournamentID { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string TournamentName { get; set; }
    }
}
