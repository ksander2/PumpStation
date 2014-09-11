using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using PumpStationBase.Domain;

namespace PumpStationBase.Models.Mapping
{
    public class StatementMap : EntityTypeConfiguration<Statement>
    {
        public StatementMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Statement");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MonthId).HasColumnName("MonthId");
            this.Property(t => t.Value).HasColumnName("Value");

            // Relationships
            this.HasRequired(t => t.Month)
                .WithMany(t => t.Statements)
                .HasForeignKey(d => d.MonthId);

        }
    }
}
