using System.ComponentModel.DataAnnotations.Schema;

namespace mini_3.Models
{
    public class User
    {
        
        public int UserID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string Contact_no { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
    }
}
