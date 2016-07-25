using System;
using System.Collections.Generic;

namespace ToplivoCodeFirst.Models
{
    interface IRepository<T> where T:class
    {
        List<T> GetAll();
        T Get(int id);
        T GetNumberItems(int numberItems);
        List<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Delete(T item);
        void Update(T item);

    }
}
