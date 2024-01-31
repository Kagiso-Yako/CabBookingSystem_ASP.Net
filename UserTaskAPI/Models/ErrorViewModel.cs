namespace CabBooking.Models
{
    public class ErrorViewModel : BaseModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}