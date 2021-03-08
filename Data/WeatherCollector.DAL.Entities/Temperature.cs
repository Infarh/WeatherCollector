using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WeatherCollector.DAL.Entities
{
    [Table("Temperature")]
    public class Temperature : FloatMeasurement { }

    //public class TemperatureEntityTypeConfiguration : IEntityTypeConfiguration<Temperature>
    //{
    //    public void Configure(EntityTypeBuilder<Temperature> entity)
    //    {
    //        entity
    //           .Property(b => b.Value)
    //           .HasPrecision(18, 2);
    //    }
    //}
}