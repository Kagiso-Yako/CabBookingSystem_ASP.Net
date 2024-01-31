

namespace CabBooking.Models
{
    public class RideModel : BaseModel
    {
        public string? Location { get; set; }

        public string? Destination { get; set; }

        public float cost { get; set; }

        public float tip { get; set; }

        public string? PassengerID { get; set; }

        public string? DriverID { get; set; }

        public int DriverRating { get; set; }

        public int PassengerRatingm { get; set; }
    }
}
