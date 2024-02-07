namespace CabBooking.Models
{
    public class UserModel : BaseModel
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public int Rating { get; set; } = -1;

        public int Trips { get; set; } = 0;

        public DateTime DateAccountCreated { get; set; } = DateTime.Now;

        public DateTime ? DateAccountDeactivated { get; set; } = null;

        public bool AccountActive { get; set; } = true;

        public bool AccountSuspended { get; set; } = false;
    }
}
