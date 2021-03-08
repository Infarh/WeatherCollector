using System;
using System.ComponentModel.DataAnnotations;
using WeatherCollector.DAL.Entities.Base;

namespace WeatherCollector.DAL.Entities
{
    public abstract class Measurement : Entity
    {
        public DateTime Time { get; set; } = DateTime.Now;

        public DateTime RegistrationTime { get; set; } = DateTime.Now;

        [Required]
        public virtual Place Place { get; set; }
    }
}
