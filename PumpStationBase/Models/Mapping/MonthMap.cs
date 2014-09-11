using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using PumpStationBase.Domain;

namespace PumpStationBase.Models.Mapping
{
    public class MonthMap : EntityTypeConfiguration<Month>
    {
        public MonthMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.MonthName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Month");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MonthName).HasColumnName("MonthName");
        }
    }
}
