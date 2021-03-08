using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WeatherCollector.DAL.Entities
{
    [Table("Pressure")]
    public class Pressure : FloatMeasurement { }

    //public class PressureEntityTypeConfiguration : IEntityTypeConfiguration<Pressure>
    //{
    //    public void Configure(EntityTypeBuilder<Pressure> entity)
    //    {
    //        entity
    //           .Property(b => b.Value)
    //           .HasPrecision(18, 2);
    //    }
    //}
}