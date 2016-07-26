using System;
using System.Collections.Generic;

namespace ToplivoCodeFirst.Models
{
    interface IRepository<T>:IDisposable where T:class
    {
        IEnumerable<T> GetAll();
        T Get(int id);//получить объект по индексу
        IEnumerable<T> GetNumberItems(int numberItems); //получить коллекцию numberItems объектов
        IEnumerable<T> Find(Func<T, bool> predicate);//получить коллекцию объектов, удовлетворяющих заданному условию
        void Create(T item);//создать объект
        void Delete(int id);//удалить объект
        void Update(T item);//обновить объект
        void Save();  // сохранение сделанных изменений

    }
}
