using System;
using System.Collections.Generic;

namespace ToplivoCodeFirst.Models
{
    public class OperationRepository : IRepository<Operation>
    {
        public void Create(Operation item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Operation item)
        {
            throw new NotImplementedException();
        }

        public List<Operation> Find(Func<Operation, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Operation Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Operation> GetAll()
        {
            throw new NotImplementedException();
        }

        public Operation GetNumberItems(int numberItems)
        {
            throw new NotImplementedException();
        }

        public void Update(Operation item)
        {
            throw new NotImplementedException();
        }
    }
}