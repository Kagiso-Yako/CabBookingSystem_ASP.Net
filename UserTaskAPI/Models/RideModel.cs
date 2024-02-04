using System.ComponentModel.DataAnnotations;

namespace CabBooking.Models
{
    public class RideModel : BaseModel
    {
        [Required]
        public string? Location { get; set; }
        [Required]
        public string? Destination { get; set; }

        public string? PaymentID { get; set; }
        [Required]
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
