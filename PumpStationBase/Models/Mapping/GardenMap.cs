using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using PumpStationBase.Domain;

namespace PumpStationBase.Models.Mapping
{
    public class GardenMap : EntityTypeConfiguration<Garden>
    {
        public GardenMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Garden");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Square).HasColumnName("Square");
        }
    }
}
