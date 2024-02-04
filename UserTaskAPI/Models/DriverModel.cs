
namespace CabBooking.Models
{
    public class DriverModel : UserModel
    {
        public string? CarID { get; set; }

        public bool Busy { get; set; }

    }
}
