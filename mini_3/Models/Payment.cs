using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_3.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public string Card_no { get; set; }
        public string Name_on_card { get; set; }
        public string Bank { get; set; }
        public string Card_type { get; set; }
        public string Payment_date { get; set; }
        public string Pin { get; set; }
        public Ticket Ticket { get; set; }
    }
}
