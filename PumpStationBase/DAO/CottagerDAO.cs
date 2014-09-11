using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using PumpStationBase.Domain;

namespace PumpStationBase.DAO
{
    public class CottagerDAO : AbstractDAO<Cottager>
    {
        public CottagerDAO(PumpStationContext context): base(context)
        {
            _context = context;
        }

        public IQueryable<Cottager> GetCottagersByMonthId(int MonthId)
        {
            return _context.Cottagers.Where(x => x.MonthId == MonthId);
        }

        protected override void updateItem(Cottager item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        protected override void creatItem(Cottager item)
        {
            _context.Cottagers.Add(item);
        }

        protected override void deleteItem(Cottager item)
        {
            _context.Cottagers.Remove(item);
        }

        public int GetNextId()
        {
            if (_context.Cottagers.Count() != 0)
            {
                return _context.Cottagers.Max<Cottager>(x => x.Id) + 1;
            }
            else return 0;
        }
    }
}
