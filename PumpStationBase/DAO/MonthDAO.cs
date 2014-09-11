using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PumpStationBase.Domain;

namespace PumpStationBase.DAO
{
    public class MonthDAO : AbstractDAO<Month>
    {
        public MonthDAO(PumpStationContext context): base(context)
        {
            _context = context;
        }

        protected override void updateItem(Month item)
        {
            throw new NotImplementedException();
        }

        protected override void creatItem(Month item)
        {
            throw new NotImplementedException();
        }

        protected override void deleteItem(Month item)
        {
            throw new NotImplementedException();
        }
    }
}
