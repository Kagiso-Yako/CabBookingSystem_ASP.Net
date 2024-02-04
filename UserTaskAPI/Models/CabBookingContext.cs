using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CabBooking.Models;

namespace CabBooking.Models
{
    public class CabBookingContext : DbContext
    {
        public CabBookingContext(DbContextOptions<CabBookingContext> options) : base(options) { }

    }
}
