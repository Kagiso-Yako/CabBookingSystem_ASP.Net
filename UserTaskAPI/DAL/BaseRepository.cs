using Microsoft.EntityFrameworkCore;
using Microsoft.Build.Framework;

using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;

using CabBooking.Models;


namespace CabBooking.DAL
{
    public class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        protected readonly CabBookingContext _context;
        protected readonly DbSet<T> _DBSet;

        public BaseRepository(CabBookingContext context)
        {
            _context = context;
            _DBSet = context.Set<T>();
        }

        public T ? GetItem(string id)
        {
            var entity = _DBSet.Find(id);

            return entity;
        }

        public T[] ? GetAll()
        {
            var allEntities = _DBSet.ToArray();

            return allEntities;
        }

        public void Create(T entity)
        {
            _DBSet.Add(entity);
            Save_Changes();
        }
    
        public void Update(T entity) {
            _DBSet.Update(entity);
            Save_Changes();

        }

        protected async void Save_Changes()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
               
            }
        }

        public bool ItemsIsNull()
        {
            if (_DBSet == null || _DBSet.Any())
                return true;
            return false;
        }

        public bool ContainsItem(T entity)
        {
            if (_DBSet.Contains<T>(entity))
            {
                return true;
            }
            return false;
        }

        public async void Delete(string id) 
        {
            var entity = await _DBSet.FindAsync(id);
            if (entity != null)
            {
                _DBSet.Remove(entity);
            }
            Save_Changes();
        }

    }
}
