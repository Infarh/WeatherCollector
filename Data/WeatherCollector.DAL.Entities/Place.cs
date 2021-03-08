using System.Collections.Generic;
using WeatherCollector.DAL.Entities.Base;

namespace WeatherCollector.DAL.Entities
{
    public class Place : NamedEntity
    {
        public string Description { get; set; }

        public virtual ICollection<Temperature> Temperatures { get; set; }

        public virtual ICollection<Pressure> Pressures { get; set; }
    }
}
