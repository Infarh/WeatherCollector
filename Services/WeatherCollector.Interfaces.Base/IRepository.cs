using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WeatherCollector.Interfaces.Base.Entities;

namespace WeatherCollector.Interfaces.Base
{
    public interface IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> Items { get; }

        T Get(int id);
        Task<T> GetAsync(int id, CancellationToken Cancel = default);

        T Add(T item);
        Task<T> AddAsync(T item, CancellationToken Cancel = default);

        T Update(T item);
        Task<T> UpdateAsync(T item, CancellationToken Cancel = default);

        T Delete(T item);
        Task<T> DeleteAsync(T item, CancellationToken Cancel = default);

        T Delete(int id);
        Task<T> DeleteAsync(int id, CancellationToken Cancel = default);
    }
}
