using System.Collections.Generic;
using WeatherCollector.Interfaces.Base.Entities;

namespace WeatherCollector.Interfaces.Base
{
    public interface IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> Items { get; }

        T Get(int id);

        T Add(T item);

        T Update(T item);

        T Delete(T item);

        T Delete(int id);
    }
}
