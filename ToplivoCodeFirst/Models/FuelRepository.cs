using System;
using System.Data.Entity;
using System.Collections.Generic;

namespace ToplivoCodeFirst.Models
{
    public class FuelRepository : IRepository<Fuel>
    {
        private ToplivoContext db;
        public FuelRepository()
        {
            db = new ToplivoContext();
        }
        public void Create(Fuel item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        
        public IEnumerable<Fuel> Find(Func<Fuel, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Fuel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fuel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fuel> GetNumberItems(int numberItems)
        {
            throw new NotImplementedException();
        }

        

        public void Update(Fuel item)
        {
            throw new NotImplementedException();
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}