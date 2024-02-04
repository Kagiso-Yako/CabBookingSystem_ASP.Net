using CabBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace CabBooking.DAL
{
    public class ModeratorRepository : BaseRepository<ModeratorModel>
    {

        // Private members
        private readonly DbSet<RideModel> _DBSetRides;
        private readonly DbSet<CarModel> _DBSetCars;
        private readonly DbSet<PaymentModel> _DBSetPayment;
        private readonly DbSet<DriverModel> _DBSetDrivers;
        private readonly DbSet<UserModel> _DBSetPassengers;

        public ModeratorRepository(CabBookingContext context) : base(context) 
        {
            _DBSetCars = _context.Set<CarModel>();
            _DBSetRides = _context.Set<RideModel>();
            _DBSetPayment = _context.Set<PaymentModel>();
            _DBSetDrivers = _context.Set<DriverModel>();
            _DBSetPassengers = _context.Set<UserModel>();
        }

        /*
         *                                      Simple
        * *    Delete any user
        * *    See all rides
        * *    Suspend user
        * *    See current rides
        * *    Receive emergency Alerts
        * 
        * 
                                              Analytics
        *      SIMPLE
        * *    Active rides
        * *    Unattended emergency alerts - High priority
        * *    Gross income in day
        * *    Time of day
        * *    Number of rides in day
        * *    Average rating
        * 
        *      MODERATE
        * *    Driver rating average, distribution and standard deviation
        * *    User rating average, distribution and standard deviation
        * *    Driver turn up across the (time frame)
        * *    Passenger requests across the (time frame) - Show current time in graph.
        * *    New passengers in last (time frame) : Number and details upon request
        * *    Lost passengers in last (time frame) : Number and details upon request
        * *    Distribution of users' last rating before departure
        * *    Distribution of average user experience before departure 
        * *    New drivers in last (time frame) : Number and details upon request
        * *    Lost drivers in last (time frame) : Number and details upon request
        * *    Distribution of drivers' last rating before departure 
        * *    Distribution of driver experience before departure
        * *    Distribution of average driver rating across time of day
        * *    
        * 
        */
    }
}
