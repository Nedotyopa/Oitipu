using System;
using System.Collections.Generic;

namespace ToplivoCodeFirst.Models
{
    public class TankRepository : IRepository<Tank>
    {
        public void Create(Tank item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Tank item)
        {
            throw new NotImplementedException();
        }

        public List<Tank> Find(Func<Tank, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Tank Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tank> GetAll()
        {
            throw new NotImplementedException();
        }

        public Tank GetNumberItems(int numberItems)
        {
            throw new NotImplementedException();
        }

        public void Update(Tank item)
        {
            throw new NotImplementedException();
        }
    }
}