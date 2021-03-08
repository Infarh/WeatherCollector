using WeatherCollector.Interfaces.Base.Entities;

namespace WeatherCollector.Interfaces.Base
{
    public interface IRepositoryNamed<T> : IRepository<T> where T : class, INamedEntity
    {
        T Get(string Name);
    }
}
