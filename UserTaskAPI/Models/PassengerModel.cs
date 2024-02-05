using System.ComponentModel.DataAnnotations.Schema;

namespace CabBooking.Models
{
    public class PassengerModel : UserModel
    {
        [NotMapped]
        public string[] ? FavDestinations { get; set; } 
    }
}
