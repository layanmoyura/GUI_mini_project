using System.ComponentModel.DataAnnotations.Schema;

namespace mini_3.Models
{
    public class Admin
    {
       
        public int AdminID { get; set; }
        public string Name { get; set; }
        public string workplace { get; set; }
        public string Contact_no { get; set; }
        public string Password { get; set; }
    }
}
