using CabBooking.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CabBooking.DAL
{
    public class UserDataRepository : BaseRepository<UserModel>
    {
        // Private members
        private readonly DbSet<RideModel> _DBSetRides;
        private readonly DbSet<PaymentModel> _DBSetPayment;


        // Public members
        public UserDataRepository(CabBookingContext context) : base(context) {
            _DBSetRides = _context.Set<RideModel>();
            _DBSetPayment = _context.Set<PaymentModel>();
            
        }

        //  Summary:
        //      Add ride to database - This is considered a request, since no driver has yet accepted the offer.
        //      
        public void RequestRide(RideModel request)
        {
            _DBSetRides.Add(request);
            Save_Changes();
        }

        //  Summary:
        //      Remove ride from database - If the trip was never started then it can be cancelled.

        public void CancelTrip(string tripID)
        {
            var entity = _DBSetRides.Find(tripID);
            if (entity != null)
                _DBSetRides.Remove(entity);

        }

        //  Summary:
        //      Remove ride from database - If the trip was never started then it can be cancelled.

        public RideModel[] GetPassengerTrips(string UserID)
        {
            return _DBSetRides.Where(entity => entity.PassengerID == UserID).ToArray<RideModel>();
        }

         //  Summary:
         //      Get available drivers

        public DriverModel[] AvailableDrivers()
        {
            return _context.Set<DriverModel>().Where(entity => entity.Busy == false
                                            && entity.AccountActive == true).ToArray();
        }

         // Summary:
         //      Adds payment instance created by controller to the database.

        public void MakePayment(PaymentModel payment)
        {
            _DBSetPayment.Add(payment);
            Save_Changes();
        }


        //                           Driver Methods
        //    Start ride - Capture start time
        //    End ride - Capture stop time and cost
        //

        //  Summary:
        //      Get all the trips for a specific driver.

        public RideModel[] GetDriverTrips(string UserID)
        {
            return _DBSetRides.Where(entity => entity.DriverID == UserID).ToArray<RideModel>();
        }

        //  Summary:
        //     Add RideModel entity to database from the controller
        public void StartTrip(RideModel trip)
        {
            // Server side entity modifications.

            trip.Active = true;
            trip.StartTime = DateTime.Now;
            
            // Add to database
            _DBSetRides.Add(trip);
            Save_Changes();
        }

        /*
         * Summary:
         *      Updates trip information when the trip is over.
         *      Called when trip ends and,  when the payment is finalized and the ratings are given.
         */

        public void StopTrip(RideModel trip)
        {
            // Server side entity modifications
            // Performed when this method is called to stop the trip
            if (trip != null && trip.Active == true) { 
                trip.EndTime = DateTime.Now;
                trip.Active = false;
            }

            if (trip != null)
                _DBSetRides.Update(trip);
        }


       /* 
        * 
        *                                        Analytical data : Used by drivers
        *                         
        * *    Distribution of rating
        * *    Time of day vs Number of rides
        * *    Busiest times of day
        * *    Days most likely to get rides
        * *    Busiest days of week
        * *    +
        */

        //  Summary:
        //      Distribution of rating for the specified driver if Driver id null, then general.
        public Dictionary<int, int> RatingDistribution(string ? DriverID)
        {
            var rating = _DBSetRides.Where(trips => trips.DriverID == (DriverID ?? trips.DriverID))
                    ?.GroupBy(trips => trips.DriverRating)
                    ?.Select(trips => new { DriverRating = trips.Key, count = trips.Count() })
                    ?.ToArray();

            Dictionary<int, int> RatingCountDict = new();   

            for (int i = 0; i < rating?.Length; i++)
            {
                RatingCountDict.Add(rating[i].DriverRating, rating[i].count);

            }

            return RatingCountDict;
        }

        // Summary:
        //      Distribution of work across different hours of day. This lets drivers know the best
        //      Times for them to work. 
        //      When the DriverID is not given, general performance/busyness is returned
        public Dictionary<int, int> WorkVsTimeDistribution(string ? DriverID)
        {
            var rating = _DBSetRides.Where(trips => trips.DriverID == (DriverID ?? trips.DriverID))
                ?.GroupBy(trips => trips.StartTime.Hour)
                ?.Select(trips => new { Hour = trips.Key, count = trips.Count() })
                ?.ToArray();

            Dictionary<int, int> HourCountDict = new();

            for (int i = 0; i < rating?.Length; i++)
            {
                HourCountDict.Add(rating[i].Hour, rating[i].count);

            }
            return HourCountDict;
        }

        // Summary:
        //      Distribution of work across different days of the week. This lets drivers know the best
        //      days for them to work. 
        //      When the DriverID is not given, general performance/busyness is returned instead


        public Dictionary<DayOfWeek , int> WorkVsDayDistribution(string ? DriverID)
        {   
            var rating = _DBSetRides.Where(trips => trips.DriverID == (DriverID ?? trips.DriverID))
                ?.GroupBy(trips => trips.StartTime.DayOfWeek)
                ?.Select(trips => new { DoW = trips.Key, count = trips.Count() })
                ?.ToArray();

            Dictionary<DayOfWeek, int> DayCountDict = new();
            
            for (int i = 0; i < rating?.Length; i++)
            {
                DayCountDict.Add(rating[i].DoW, rating[i].count);

            }
            return DayCountDict;
        }

    }
}
