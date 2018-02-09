using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using PumpStationBase.Domain;

namespace PumpStationBase.DAO
{
    public class StatementDAO : AbstractDAO<Statement>
    {
        public StatementDAO(PumpStationContext context): base(context)
        {
            _context = context;
        }

        protected override void updateItem(Statement item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        protected override void creatItem(Statement item)
        {
            throw new NotImplementedException();
        }

        public Statement GetStatementByMonthId(int MonthId)
        {
            return _context.Statements.Where(x => x.Id == MonthId).FirstOrDefault();
        }

        protected override void deleteItem(Statement item)
        {
            throw new NotImplementedException();
        }
    }
}
