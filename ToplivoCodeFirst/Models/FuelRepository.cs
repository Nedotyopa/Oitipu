using System;
using System.Data.Entity;
using System.Collections.Generic;

namespace ToplivoCodeFirst.Models
{
    public class FuelRepository : IRepository<Fuel>
    {
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

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты).
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~FuelRepository() {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            // GC.SuppressFinalize(this);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}