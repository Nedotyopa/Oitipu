﻿using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using ToplivoCodeFirst.PL;

namespace ToplivoCodeFirst.Models
{
    public class OperationRepository : IRepository<Operation>
    {
        private ToplivoContext db;
        public OperationRepository(ToplivoContext context)
        {
            db = context;
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
        public OperationPage GetAllPaged(int page = 1, int pageSize = 20)
        {
            IEnumerable<Operation> operations = db.Operations.OrderBy(o=>o.OperationID).Skip((page - 1) * pageSize).Take(pageSize).Include(o => o.Fuel).Include(o => o.Tank);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = operations.Count() };
            OperationPage viewoperations = new OperationPage { PageInfo = pageInfo, Operations = operations };
            return viewoperations;
        }
        Page<Operation> IRepository<Operation>.GetAllPaged(int page, int pageSize)
        {
            IEnumerable<Operation> operations = db.Operations.OrderBy(o => o.OperationID).Skip((page - 1) * pageSize).Take(pageSize).Include(o => o.Fuel).Include(o => o.Tank);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = operations.Count() };
            Page<Operation> viewoperations = new Page<Operation> { PageInfo = pageInfo, PagedItems = operations };
            return viewoperations;
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