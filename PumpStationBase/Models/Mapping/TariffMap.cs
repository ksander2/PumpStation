using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using PumpStationBase.Domain;

namespace PumpStationBase.Models.Mapping
{
    public class TariffMap : EntityTypeConfiguration<Tariff>
    {
        public TariffMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Tariff");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TariffPrice).HasColumnName("TariffPrice");
        }
    }
}
