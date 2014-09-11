using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using PumpStationBase.Domain;

namespace PumpStationBase.Models.Mapping
{
    public class CottagerMap : EntityTypeConfiguration<Cottager>
    {
        public CottagerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Cottager");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MonthId).HasColumnName("MonthId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.GardenId).HasColumnName("GardenId");

            // Relationships
            this.HasRequired(t => t.Garden)
                .WithMany(t => t.Cottagers)
                .HasForeignKey(d => d.GardenId);
            this.HasRequired(t => t.Month)
                .WithMany(t => t.Cottagers)
                .HasForeignKey(d => d.MonthId);

        }
    }
}
