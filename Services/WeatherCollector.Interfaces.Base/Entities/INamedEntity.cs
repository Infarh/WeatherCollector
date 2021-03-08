using System.ComponentModel.DataAnnotations;

namespace WeatherCollector.Interfaces.Base.Entities
{
    public interface INamedEntity : IEntity
    {
        [Required]
        string Name { get; set; }
    }
}
