
namespace CabBooking.Models
{
    public class DriverModel : BaseModel
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? CarID { get; set; }
        
        public int Rating { get; set; }

        public int Trips { get; set; }
    }
}
