

namespace CabBooking.Models
{
    public class PassengerModel : BaseModel
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public int Rating { get; set;  }

        public int Trips { get; set; }
    }
}
