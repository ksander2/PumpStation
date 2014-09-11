using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PumpStationBase.DAO
{
    public class UnitOfWork : IDisposable
    {
        private PumpStationContext _context = new PumpStationContext();
        
        private CottagerDAO _CottagerDAO;
        private GardenDAO _GardenDAO;
        private MonthDAO _MonthDAO;
        private StatementDAO _StatementDAO;
        private TariffDAO _TariffDAO;

        public UnitOfWork()
        {
            _context = new PumpStationContext();
            _CottagerDAO = new CottagerDAO(_context);
            _GardenDAO = new GardenDAO(_context);
            _MonthDAO = new MonthDAO(_context);
            _StatementDAO = new StatementDAO(_context);
            _TariffDAO = new TariffDAO(_context);
            
        }

        public CottagerDAO CottagerDAO
        {
            get { return _CottagerDAO; }
        }

        public GardenDAO GardenDAO
        {
            get { return _GardenDAO; }
        }

        public MonthDAO MonthDAO
        {
            get { return _MonthDAO; }
        }

        public StatementDAO StatementDAO
        {
            get { return _StatementDAO; }
        }

        public TariffDAO TariffDAO
        {
            get { return _TariffDAO; }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
