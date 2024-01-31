using System.Collections.Generic;
using CabBooking.Models;

namespace CabBooking.DAL
{
    public interface IRepository<T>
    {
        T[] ? GetAll();
        T ? GetItem(string id);
        void Create(T Task);
        void Update(T Task);
        void Delete(string id);
    }
}
