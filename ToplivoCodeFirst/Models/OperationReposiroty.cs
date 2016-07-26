using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace ToplivoCodeFirst.Models
{
    public class OperationRepository : IRepository<Operation>
    {
        private ToplivoContext db;
        public OperationRepository()
        {
            db = new ToplivoContext();
        }
        public void Create(Operation operation)
        {
            db.Operations.Add(operation);
        }

        public void Delete(int id)
        {
            Operation operation=db.Operations.Find(id);
            if (operation != null)
            {
                db.Operations.Remove(operation);
            }
            
        }

        public IEnumerable<Operation> Find(Func<Operation, bool> predicate)
        {
            return db.Operations.Where(predicate).ToList();
        }

        public Operation Get(int id)
        {
            return db.Operations.Find(id);
        }

        public IEnumerable<Operation> GetAll()
        {
            return db.Operations.Include(o=>o.Fuel).Include(o=>o.Tank);
        }

        public IEnumerable<Operation> GetNumberItems(int numberItems)
        {
            return db.Operations.Take(numberItems).Include(o => o.Fuel).Include(o => o.Tank).OrderByDescending(o=>o.Date);
        }

        public void Update(Operation operation)
        {
            db.Entry(operation).State=EntityState.Modified;


        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
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