using Microsoft.EntityFrameworkCore.Metadata;
using System.Buffers;

namespace CabBooking.Models
{
    public class CarModel : BaseModel
    {
        public string? Model { get; set;}

        public string? Registration { get; set;}

        public string? Owner { get; set; }

        public string? DriverID { get; set; }

    }
}
