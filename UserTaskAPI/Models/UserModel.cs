namespace CabBooking.Models
{
    public class UserModel : BaseModel
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public int Rating { get; set; }

        public int Trips { get; set; }

        public DateTime DateAccountCreated { get; set; }

        public DateTime DateAccountDeactivated { get; set; }

        public bool AccountActive { get; set; }

        public bool AccountSuspended { get; set; }
    }
}
