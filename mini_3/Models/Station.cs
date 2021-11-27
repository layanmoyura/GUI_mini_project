namespace mini_3.Models
{
    public class Station
    {
        
        public int StationID {get; set;}
        public string Station_name { get; set; }
        public int Crowd_capacity { get; set; }
        public int Distance { get; set; }
        public Admin Admin { get; set; }
        
    }
}
