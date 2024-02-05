using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CabBooking.Models;

namespace CabBooking.Models
{
    public class CabBookingContext : DbContext
    {
        public CabBookingContext(DbContextOptions<CabBookingContext> options) : base(options) { }

        public DbSet<BaseModel> BaseModels { get; set; }

        public DbSet<UserModel> UserModels { get; set; }

        public DbSet<CabBooking.Models.DriverModel>? DriverModel { get; set; }

        public DbSet<CabBooking.Models.ModeratorModel>? ModeratorModel { get; set; }

        public DbSet<CabBooking.Models.PassengerModel>? PassengerModel { get; set; }

    }
}
