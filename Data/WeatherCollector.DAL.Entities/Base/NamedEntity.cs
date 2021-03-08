using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WeatherCollector.Interfaces.Base.Entities;

namespace WeatherCollector.DAL.Entities.Base
{
    [Index(nameof(Name))]
    public abstract class NamedEntity : Entity, INamedEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
