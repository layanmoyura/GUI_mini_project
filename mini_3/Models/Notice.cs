using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_3.Models
{
    public class Notice
    {
        public int NoticeID { get; set; }
        public DateTime DateTime { get; set; }
        public string Notice_content { get; set; }
        public Station Station { get; set; }
        public Admin Admin { get; set; }
    }
}
