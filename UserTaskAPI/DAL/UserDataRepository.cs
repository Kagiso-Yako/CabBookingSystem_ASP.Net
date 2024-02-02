using CabBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace CabBooking.DAL
{
    public class UserDataRepository<UserModel> : BaseRepository<UserModel> where UserModel : BaseModel
    {
        // Private members
        private readonly DbSet<RideModel> _DBSetRides;
        private readonly DbSet<CarModel> _DBSetCars;
        private readonly DbSet<PaymentModel> _DBSetPayment;
        public UserDataRepository(CabBookingContext context) : base(context) {
            _DBSetCars = _context.Set<CarModel>();
            _DBSetRides = _context.Set<RideModel>();
            _DBSetPayment = _context.Set<PaymentModel>();
            
        }

        /* Methods implemented in this class go beyond simple entity CRUD methods.
         * 
         * To be implemented:
         * *                        Passenger Methods
         * *    Get all rides for a specific Passenger / Driver given user ID
         * *    Get all available drivers (Will be overriden to select drivers over certain rating)
         * *    Make payment
         */

        public RideModel[] GetDriverTrips(string UserID)
        {
            return _DBSetRides.Where(entity => entity.DriverID == UserID).ToArray<RideModel>();
        }
        public RideModel[] GetPassengerTrips(string UserID)
        {
            return _DBSetRides.Where(entity => entity.PassengerID == UserID).ToArray<RideModel>();
        }

        public DriverModel[] AvailableDrivers()
        {
            return _context.Set<DriverModel>().Where<DriverModel>(entity => entity.Busy == false
                                            && entity.AccountActive == true).ToArray();
        }

        public void MakePayment(PaymentModel payment)
        {
            _DBSetPayment.Add(payment);
        }

        
         /*                           Driver Methods
         * *    Start ride - Capture start time
         * *    End ride - Capture stop time and cost
         * *    Rate user - Add results to user profile and ride info
         * 
         *                         Moderator Methods
         * *    Delete any user
         * *    See all rides
         * *    Suspend user
         * *    See current rides
         * *    Receive emergency Alerts
         * * 
         * *******************************************************************************************************
         * 
         *            Analytical data derived from existing Database entries
         *                         
         *                            Driver Data
         * *    Distribution of rating
         * *    Time of day vs Number of rides
         * *    Busiest times of day
         * *    Days most likely to get rides
         * *    Busiest days of week
         * *    
         *                       Moderator data
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
