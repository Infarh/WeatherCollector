using System.ComponentModel.DataAnnotations;

namespace WeatherCollector.DAL.Entities.Base
{
    public abstract class NamedEntity : Entity
    {
        [Required]
        public string Name { get; set; }
    }
}
