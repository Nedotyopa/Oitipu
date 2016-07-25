using System;
using System.Collections.Generic;

namespace ToplivoCodeFirst.Models
{
    interface IRepository<T>:IDisposable where T:class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> GetNumberItems(int numberItems);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Delete(int id);
        void Update(T item);
        void Save();  // сохранение изменений

    }
}
