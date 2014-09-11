using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using PumpStationBase.Domain;

namespace PumpStationBase.DAO
{
    public class TariffDAO : AbstractDAO<Tariff>
    {
        public TariffDAO(PumpStationContext context) : base(context)
        {
            _context = context;
        }

        public Tariff getTariff()
        {
            return _context.Tariffs.FirstOrDefault();
        }

        protected override void updateItem(Tariff item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        protected override void creatItem(Tariff item)
        {
            throw new NotImplementedException();
        }

        protected override void deleteItem(Tariff item)
        {
            throw new NotImplementedException();
        }
    }
}
