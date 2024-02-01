using CabBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace CabBooking.DAL
{
    public class UserRepository<UserModel> : BaseRepository<UserModel> where UserModel : BaseModel
    {
        private readonly CabBookingContext _context;
        private readonly DbSet<UserModel> _Users;
         
        public UserRepository(CabBookingContext context) : base(context) 
        {
            _context = context;
            _Users = _context.Set<UserModel>();
        }

    }
}
