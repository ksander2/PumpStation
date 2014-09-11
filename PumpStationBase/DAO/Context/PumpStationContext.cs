using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using PumpStationBase.Models.Mapping;
using PumpStationBase.Domain;

namespace PumpStationBase.DAO
{
    public partial class PumpStationContext : DbContext
    {
        static PumpStationContext()
        {
            Database.SetInitializer<PumpStationContext>(new DbInitializer());
        }

        public PumpStationContext()
            : base("Name=PumpStationContext")
        {
        }

        public DbSet<Cottager> Cottagers { get; set; }
        public DbSet<Garden> Gardens { get; set; }
        public DbSet<Month> Months { get; set; }
        public DbSet<Statement> Statements { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CottagerMap());
            modelBuilder.Configurations.Add(new GardenMap());
            modelBuilder.Configurations.Add(new MonthMap());
            modelBuilder.Configurations.Add(new StatementMap());
            modelBuilder.Configurations.Add(new TariffMap());
        }
    }
}
