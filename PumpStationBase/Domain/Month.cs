using System;
using System.Collections.Generic;

namespace PumpStationBase.Domain
{
    public partial class Month : EntityBase
    {
        public Month()
        {
            this.Cottagers = new List<Cottager>();
            this.Statements = new List<Statement>();
        }

        public int Id { get; set; }
        public string MonthName { get; set; }
        public virtual ICollection<Cottager> Cottagers { get; set; }
        public virtual ICollection<Statement> Statements { get; set; }
    }
}
