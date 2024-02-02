
namespace CabBooking.Models
{
    public class DriverModel : BaseModel
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? CarID { get; set; }
        
        public int Rating { get; set; }

        public int Trips { get; set; }

        public bool Busy { get; set; }

        public DateTime DateAccountCreated { get; set; }

        public DateTime DateAccountDeactivated { get; set; }

        public bool AccountActive { get; set; }
    }
}
