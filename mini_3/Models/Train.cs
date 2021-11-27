using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_3.Models
{
    public class Train
    {
        

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string TrainID { get; set; }
        public string Starting_at { get; set; }
        public string Destination { get; set; }
        public string Starting_time { get; set; }
        public string Ending_time { get; set; }
        public string Location { get; set; }
        public int Available_seats { get; set; }
        public Admin Admin { get; set; }
    }
}
