using System.Threading;
using System.Threading.Tasks;
using WeatherCollector.Interfaces.Base.Entities;

namespace WeatherCollector.Interfaces.Base
{
    public interface IRepositoryNamed<T> : IRepository<T> where T : class, INamedEntity
    {
        T Get(string Name);
        Task<T> GetAsync(string Name, CancellationToken Cancel = default);
    }
}
