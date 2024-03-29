﻿using CabBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace CabBooking.DAL
{
    public class ModeratorRepository : UserDataRepository
    {

        // Private members
        private readonly DbSet<RideModel> _DBSetRides;
        private readonly DbSet<CarModel> _DBSetCars;
        private readonly DbSet<PaymentModel> _DBSetPayment;
        private readonly DbSet<ModeratorModel> _DBSetMods;

        public ModeratorRepository(CabBookingContext context) : base(context) 
        {
            _DBSetCars = _context.Set<CarModel>();
            _DBSetRides = _context.Set<RideModel>();
            _DBSetPayment = _context.Set<PaymentModel>();
            _DBSetMods = _context.Set<ModeratorModel>();

        }

        public void CreateMod(ModeratorModel entity)
        {
            try
            {
                _DBSetMods.Add(entity);
                Save_Changes();
            }
            catch { }

        }

        public ModeratorModel ? GetModAccount(string id)
        {
            try
            {
                return _DBSetMods?.Find(id);
            }
            catch {
                return null;
            }

        }

        public void UpdateMod(ModeratorModel entity)
        {
            try {
                _DBSetMods.Update(entity);
                Save_Changes();
            }
            catch { }
        }

        /*
         *                                      Simple
        * *    Delete any user - complete
        * *    See all rides - complete
        * *    Suspend user
        * *    See current rides - complete
        * *    Receive emergency Alerts ** Figure out how to update page without refreshing
        * 
        */



        public RideModel[] OngoingTrips()
        {
            return _DBSetRides.Where(trips => trips.Active == true).ToArray<RideModel>();
        }

        public RideModel[] AllTrips()
        {
            return _DBSetRides.ToArray<RideModel>();
        }

        public int SuspendUser(string? UserID)
        {
            if (UserID == null)
                // User ID not given code: -1
                return -1;
            try
            {
                var entity = _DBSet.Find(UserID);
                if (entity != null)
                {
                    entity.AccountSuspended = true;
                    entity.DateAccountDeactivated = DateTime.Now;
                    
                }
                else
                {
                    // Entity not found code:  -2
                    return -2;
                }
                _DBSet.Update(entity);
                return 1;
            }
            catch
            {
                // Update raised exception code: -3 
                return -3;
            }
        }



        //                                      Analytics
        //      SIMPLE
        //    Active rides
        
        public RideModel[] ActiveRides()
        {
            return _DBSetRides.Where(entity => entity.Active == true)?.ToArray() ?? Array.Empty<RideModel>(); 
        }
        
        /* *    Unattended emergency alerts - High priority - Not Core
         /* *    Time of day
         * *    Number of rides in day
         * *    Average rating
         */
        
        public PaymentModel[] GetPayments(string ? id)
        {
            if (id == null )
                return _DBSetPayment.ToArray();
            return _DBSetPayment.Where(entity => entity.CustomerID == id)?.ToArray() ?? Array.Empty<PaymentModel>();
        }

        public PaymentModel ? GetPaymentByID(string ? id)
        {
            if (id == null)
                return null;
            return _DBSetPayment.Find(id);
        }

        public CarModel[] GetCars()
        {
            return _DBSetCars.ToArray();
        }

        public CarModel ? GetCarByID(string id)
        {
            return _DBSetCars.Find(id);
        }

        public CarModel[] GetCarByModel(string model)
        {
            return _DBSetCars.Where(entity => entity.Model == model)?.ToArray() ?? Array.Empty<CarModel>();
        }

        public CarModel[] GetCarsByRegistration(string registration)
        {
            return _DBSetCars.Where(entity => entity.Registration == registration).ToArray() ?? Array.Empty<CarModel>();
        }

        /*      MODERATE
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
