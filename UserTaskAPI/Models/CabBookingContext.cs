using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CabBooking.Models
{
    public class CabBookingContext : DbContext
    {
        public CabBookingContext(DbContextOptions<CabBookingContext> options) : base(options) { }

    }
}
