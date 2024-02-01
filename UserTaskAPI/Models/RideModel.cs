

namespace CabBooking.Models
{
    public class RideModel : BaseModel
    {
        public string? Location { get; set; }

        public string? Destination { get; set; }

        public string? PaymentID { get; set; }

        public string? PassengerID { get; set; }

        public string? DriverID { get; set; }

        public int DriverRating { get; set; }

        public int PassengerRating { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool EmergencyFlag { get; set; }

        public bool Active { get; set; }
        
    }
}
