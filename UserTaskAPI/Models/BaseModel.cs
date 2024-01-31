using System.ComponentModel.DataAnnotations;

namespace CabBooking.Models
{
    public class BaseModel
    {
        [Key]
        public string? ID { get; set; }
    }
}
