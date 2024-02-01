namespace CabBooking.Models
{
    public class PaymentModel : BaseModel
    {
        public float TotalAmount { get; set; }

        public float Cost { get; set; }

        public float Tip { get; set; }

        public String? PaymentType { get; set; }
    }
}
