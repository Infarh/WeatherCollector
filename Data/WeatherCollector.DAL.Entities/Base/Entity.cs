using WeatherCollector.Interfaces.Base.Entities;

namespace WeatherCollector.DAL.Entities.Base
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
