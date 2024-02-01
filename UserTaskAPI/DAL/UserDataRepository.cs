using CabBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace CabBooking.DAL
{
    public class UserDataRepository<UserModel> : BaseRepository<UserModel> where UserModel : BaseModel
    {
        public UserDataRepository(CabBookingContext context) : base(context) { }

        /* Methods implemented in this class go beyond simple entity CRUD methods.
         * 
         * To be implemented:
         * *                        Passenger Methods
         * *    Get all rides for a specific Passenger / Driver given user ID
         * *    Get all available drivers (Will be overriden to select drivers over certain rating)
         * *    Make payment
         * 
         *                           Driver Methods
         * *    Start ride - Capture start time
         * *    End ride - Capture stop time and cost
         * *    Rate user - Add results to user profile and ride info
         * 
         *                         Moderator Methods
         * *    Delete any user
         * *    See all rides
         */

    }
}
