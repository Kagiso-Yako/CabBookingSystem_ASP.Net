
namespace CabBooking.Models
{
    public class DriverModel : UserModel
    {
        public string? CarID { get; set; } = string.Empty;

        public bool Busy { get; set; } = false;

    }
}
