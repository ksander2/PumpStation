using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PumpStationBase.Domain;

namespace PumpStationBase.DAO
{
    public class GardenDAO : AbstractDAO<Garden>
    {
        public GardenDAO(PumpStationContext context): base(context)
        {
            _context = context;
        }

        protected override void updateItem(Garden item)
        {
            throw new NotImplementedException();
        }

        protected override void creatItem(Garden item)
        {
            throw new NotImplementedException();
        }

        protected override void deleteItem(Garden item)
        {
           // throw new NotImplementedException();
        }

        

        public int GetNextId()
        {
            if (_context.Gardens.Count() != 0)
            {
                return _context.Gardens.Max<Garden>(x => x.Id) + 1;
            }
            else return 0;
        }
    }
}
